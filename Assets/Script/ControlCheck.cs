using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlCheck : MonoBehaviour
{
    public GameObject _control;

    // Start is called before the first frame update
    void Start()
    {
        // 全デバイスを取得
        var devices = InputSystem.devices;
        foreach (var device in devices)
        {
            if (device is Gamepad)
            {//デバイスがゲームパッド(コントローラー)の時だけ処理
                Gamepad gamepad = device as Gamepad;
                _control.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        //デバイスの接続/切断のイベントに処理登録
        InputSystem.onDeviceChange += OnDeviceChange;
    }

    private void OnDisable()
    {
        //デバイスの接続/切断のイベントの処理解除
        InputSystem.onDeviceChange -= OnDeviceChange;
    }

    ///デバイスの変更があった
    private void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        if (device is Gamepad)
        {//デバイスがゲームパッド(コントローラー)の時だけ処理
            switch (change)
            {
                case InputDeviceChange.Added:
                    _control.SetActive(true);
                    break;
                case InputDeviceChange.Removed:
                    _control.SetActive(false);
                    break;
            }
        }
    }
}
