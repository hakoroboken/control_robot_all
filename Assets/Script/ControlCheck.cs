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
        // �S�f�o�C�X���擾
        var devices = InputSystem.devices;
        foreach (var device in devices)
        {
            if (device is Gamepad)
            {//�f�o�C�X���Q�[���p�b�h(�R���g���[���[)�̎���������
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
        //�f�o�C�X�̐ڑ�/�ؒf�̃C�x���g�ɏ����o�^
        InputSystem.onDeviceChange += OnDeviceChange;
    }

    private void OnDisable()
    {
        //�f�o�C�X�̐ڑ�/�ؒf�̃C�x���g�̏�������
        InputSystem.onDeviceChange -= OnDeviceChange;
    }

    ///�f�o�C�X�̕ύX��������
    private void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        if (device is Gamepad)
        {//�f�o�C�X���Q�[���p�b�h(�R���g���[���[)�̎���������
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
