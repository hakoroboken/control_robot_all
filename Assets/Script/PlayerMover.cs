using System;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    private GameInputs _gameInputs;

    [SerializeField] private Vector2 _moveInputValue;
    [SerializeField] private Vector2 _lockInputValue;

    public string log;

    public float sight_x = 0;
    public float sight_y = 0;

    public float _mec;

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

        _gameInputs.Player.Reset.performed += OnReset;

        _gameInputs.Player.Mechanism.performed += OnMecStart;
        _gameInputs.Player.Mechanism.canceled += OnMecEnd;

        // Input Actionを機能させるためには、
        // 有効化する必要がある
        _gameInputs.Enable();
    }

    private void Start()
    {
        _mec = 100;
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
        _moveInputValue = context.ReadValue<Vector2>();
    }

    private void OnLock(InputAction.CallbackContext context)
    {
        // Lockアクションの入力取得
        _lockInputValue = context.ReadValue<Vector2>();
        _lockInputValue.y *= -1;
    }

    private void OnReset(InputAction.CallbackContext context)
    {
        Vector3 pos = new Vector3(0f,0f,0f);
        transform.position = pos;
        sight_x = 0;
        sight_y = 0;
    }

    private void OnMecStart(InputAction.CallbackContext context)
    {
        _mec = 200;
    }

    private void OnMecEnd(InputAction.CallbackContext context)
    {
        _mec = 100;
    }

    private void Controller()
    {
        float x = _moveInputValue.x * 0.1f;
        float z = _moveInputValue.y * 0.1f;
        float angleH = _lockInputValue.x * 2.0f;
        float angleV = _lockInputValue.y * 2.0f;

        if (sight_x >= 360)
        {
            sight_x = sight_x - 360;
        }
        else if (sight_x < 0)
        {
            sight_x = 360 - sight_x;
        }
        sight_x = sight_x + angleH;

        if (sight_y > 80)
        {
            if (angleV < 0)
            {
                sight_y = sight_y + angleV;
            }
        }
        else if (sight_y < -90)
        {
            if (angleV > 0)
            {
                sight_y = sight_y + angleV;
            }
        }
        else
        {
            sight_y = sight_y + angleV;
        }

        float dx = Mathf.Sin(sight_x * Mathf.Deg2Rad) * z + Mathf.Sin((sight_x + 90f) * Mathf.Deg2Rad) * x;

        float dz = Mathf.Cos(sight_x * Mathf.Deg2Rad) * z + Mathf.Cos((sight_x + 90f) * Mathf.Deg2Rad) * x;

        transform.Translate(dx, 0, dz, 0.0F);

        transform.localRotation = Quaternion.Euler(sight_y, sight_x, 0);
    }

    private void Update()
    {
        log = "s," + ((_moveInputValue.x + 1) * 100).ToString("F0") + "," + ((_moveInputValue.y + 1) * 100).ToString("F0") + "," + ((_lockInputValue.x + 1) * 100).ToString("F0") + "," + _mec + ",e";

        Controller();
    }
}
