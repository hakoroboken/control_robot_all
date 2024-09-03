using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class CreateMessage : MonoBehaviour
{
    private GameInputs _gameInputs;

    [SerializeField] private Vector2 _LeftInputValue;
    [SerializeField] private Vector2 _RightInputValue;

    public string log;

    public float _mec_1;
    public float _mec_2;
    public float _mec_3;

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

        _gameInputs.Player.Mec1_plus.performed += OnMec1plus;
        _gameInputs.Player.Mec1_minus.performed += OnMec1minus;
        _gameInputs.Player.Mec1_plus.canceled += OnMec1End;
        _gameInputs.Player.Mec1_minus.canceled += OnMec1End;

        _gameInputs.Player.Mec2_plus.performed += OnMec2plus;
        _gameInputs.Player.Mec2_minus.performed += OnMec2minus;
        _gameInputs.Player.Mec2_plus.canceled += OnMec2End;
        _gameInputs.Player.Mec2_minus.canceled += OnMec2End;

        _gameInputs.Player.Mec3_plus.performed += OnMec3plus;
        _gameInputs.Player.Mec3_minus.performed += OnMec3minus;
        _gameInputs.Player.Mec3_plus.canceled += OnMec3End;
        _gameInputs.Player.Mec3_minus.canceled += OnMec3End;

        _gameInputs.Player.Mec1_double.performed += OnMec1End;
        _gameInputs.Player.Mec2_double.performed += OnMec2End;
        _gameInputs.Player.Mec3_double.performed += OnMec3End;

        // Input Actionを機能させるためには、
        // 有効化する必要がある
        _gameInputs.Enable();
    }

    private void Start()
    {
        _mec_1 = 0;
        _mec_2 = 0;
        _mec_3 = 0;
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

    private void OnMec1plus(InputAction.CallbackContext context)
    {
        _mec_1 = 1;
    }

    private void OnMec1minus(InputAction.CallbackContext context)
    {
        _mec_1 = -1;
    }

    private void OnMec1End(InputAction.CallbackContext context)
    {
        _mec_1 = 0;
    }

    private void OnMec2plus(InputAction.CallbackContext context)
    {
        _mec_2 = 1;
    }
    private void OnMec2minus(InputAction.CallbackContext context)
    {
        _mec_2 = -1;
    }

    private void OnMec2End(InputAction.CallbackContext context)
    {
        _mec_2 = 0;
    }

    private void OnMec3plus(InputAction.CallbackContext context)
    {
        _mec_3 = 1;
    }

    private void OnMec3minus(InputAction.CallbackContext context)
    {
        _mec_3 = -1;
    }

    private void OnMec3End(InputAction.CallbackContext context)
    {
        _mec_3 = 0;
    }

    private void AllZero(InputAction.CallbackContext context)
    {
        _mec_1 = 0;
        _mec_2 = 0;
        _mec_3 = 0;
    }

    private void Update()
    {
        log = "s," + ((_LeftInputValue.x + 1) / 2).ToString("F3") + "," + ((_LeftInputValue.y + 1) / 2).ToString("F3") + "," + ((_RightInputValue.x + 1) / 2).ToString("F3") + "," + _mec_1 + "," + _mec_2 + "," + _mec_3 + ",e";
    }
}
