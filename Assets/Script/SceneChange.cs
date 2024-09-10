using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class scenechange : MonoBehaviour
{
    private GameInputs _gameInputs;
    private void Awake()
    {
        // Actionスクリプトのインスタンス生成
        _gameInputs = new GameInputs();

        _gameInputs.UI.Next.performed += OnNext;

        _gameInputs.Enable();
    }

    private void OnDestroy()
    {
        // 自身でインスタンス化したActionクラスはIDisposableを実装しているので、
        // 必ずDisposeする必要がある
        _gameInputs?.Dispose();
    }

    private void OnNext(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene("MainScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
