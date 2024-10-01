using System;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class CreateMessage : MonoBehaviour
{
    private GameInputs _gameInputs;

    [SerializeField] private Vector2 _LeftInputValue;
    [SerializeField] private Vector2 _RightInputValue;
    public GameObject _lslider;
    public GameObject _rslider;
    public TextMeshProUGUI _ltext;
    public TextMeshProUGUI _rtext;
    private Slider LSlider;
    private Slider RSlider;
    public float Lsensitivity = 1;
    public float Rsensitivity = 1;
    private float lx;
    private float ly;
    private float rx;

    public string log;

    public float _mec_1;
    public float _mec_2;
    public float _mec_3;

    public int Rint;
    public int Lint;

    private void Awake()
    {
        // Actionスクリプトのインスタンス生成
        _gameInputs = new GameInputs();

        // Actionイベント登録
        _gameInputs.Player.Move.started += OnMove;
        _gameInputs.Player.Move.performed += OnMove;
        _gameInputs.Player.Move.canceled += OnMove;

        _gameInputs.Player.Look.started += OnLock;
        _gameInputs.Player.Look.performed += OnLock;
        _gameInputs.Player.Look.canceled += OnLock;

        _gameInputs.Player.Mec1.performed += OnMec1;
        _gameInputs.Player.Mec1.canceled += EndMec1;

        _gameInputs.Player.Mec2.performed += OnMec2;
        _gameInputs.Player.Mec2.canceled += EndMec2;

        _gameInputs.Player.Mec3.performed += OnMec3;
        _gameInputs.Player.Mec3.canceled += EndMec3;

        _gameInputs.Player.R1.performed += OnR1;
        _gameInputs.Player.R1.canceled += EndR1;
        _gameInputs.Player.L1.performed += OnL1;
        _gameInputs.Player.L1.canceled += EndL1;

        // Input Actionを機能させるためには、
        // 有効化する必要がある
        _gameInputs.Enable();
    }

    private void Start()
    {
        _mec_1 = 0;
        _mec_2 = 0;
        _mec_3 = 0;
        Rint = 0;
        Lint = 0;

        LSlider = _lslider.GetComponent<Slider>();
        RSlider = _rslider.GetComponent<Slider>();
    }

    private void OnDestroy()
    {
        // 自身でインスタンス化したActionクラスはIDisposableを実装しているので、
        // 必ずDisposeする必要がある
        _gameInputs?.Dispose();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        // Moveアクションの入力取得
        _LeftInputValue = context.ReadValue<Vector2>();
    }

    private void OnLock(InputAction.CallbackContext context)
    {
        // Lockアクションの入力取得
        _RightInputValue = context.ReadValue<Vector2>();
        _RightInputValue.y *= -1;
    }

    private void OnMec1(InputAction.CallbackContext context)
    {
        _mec_1 = 1;
    }

    private void EndMec1(InputAction.CallbackContext context)
    {
        _mec_1 = 0;
    }

    private void OnMec2(InputAction.CallbackContext context)
    {
        _mec_2 = 1;
    }

    private void EndMec2(InputAction.CallbackContext context)
    {
        _mec_2 = 0;
    }

    private void OnMec3(InputAction.CallbackContext context)
    {
        _mec_3 = 1;
    }

    private void EndMec3(InputAction.CallbackContext context)
    {
        _mec_3 = 0;
    }

    private void OnR1(InputAction.CallbackContext context)
    {
        Rint = 1;
    }

    private void EndR1(InputAction.CallbackContext context)
    {
        Rint = 0;
    }

    private void OnL1(InputAction.CallbackContext context)
    {
        Lint = 1;
    }

    private void EndL1(InputAction.CallbackContext context)
    {
        Lint = 0;
    }

    public void changeslider()
    {
        Lsensitivity = LSlider.value;
        Rsensitivity = RSlider.value;

        if (Lsensitivity != 1) { 
            _ltext.color = new Color(1.0f, 1.0f, 0.0f, 1.0f);
        }
        else
        {
            _ltext.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        }
        if (Rsensitivity != 1)
        {
            _rtext.color = new Color(1.0f, 1.0f, 0.0f, 1.0f);
        }
        else
        {
            _rtext.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        }
    }

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == LSlider.gameObject || EventSystem.current.currentSelectedGameObject == RSlider.gameObject)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }

        lx = Lsensitivity * _LeftInputValue.x;
        ly = Lsensitivity * _LeftInputValue.y;
        rx = Rsensitivity * _RightInputValue.x;

        if(lx > 1)
        {
            lx = 1;
        }
        else if( lx < -1)
        { 
            lx = -1;
        }
        if (ly > 1)
        {
            ly = 1;
        }
        else if (ly < -1)
        {
            ly = -1;
        }
        if (rx > 1)
        {
            rx = 1;
        }
        else if (rx < -1)
        {
            rx = -1;
        }

        log = lx.ToString("F3") + "," + ly.ToString("F3") + "," + rx.ToString("F3") + "," + _mec_1 + "," + _mec_2 + "," + _mec_3 + "," + Rint + "," + Lint;
    }
}
