using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class input_manager : MonoBehaviour
{
    public CreateMessage _createMassage;

    private GameInputs gameinput;
    public TMP_Dropdown _Mode;
    public UdpSend _UdpSend;

    private InputAction mec1Action;
    private InputAction mec2Action;
    private InputAction mec3Action;

    private int now_config;

    // Start is called before the first frame update
    void Start()
    {
        gameinput = _createMassage._gameInputs;

        mec1Action = gameinput.Player.Mec1;
        mec2Action = gameinput.Player.Mec2;
        mec3Action = gameinput.Player.Mec3;
    }

    public void ChangeButton()
    {
        now_config = _Mode.value;

        if(now_config == 0) 
        {
            mec1Action.ChangeBinding(0).WithPath("<Gamepad>/buttonEast");
            mec2Action.ChangeBinding(0).WithPath("<Gamepad>/buttonNorth");
            mec3Action.ChangeBinding(0).WithPath("<Gamepad>/buttonWest");
        }
        else if(now_config == 1)
        {
            mec1Action.ChangeBinding(0).WithPath("<Gamepad>/dpad/right");
            mec2Action.ChangeBinding(0).WithPath("<Gamepad>/dpad/up");
            mec3Action.ChangeBinding(0).WithPath("<Gamepad>/dpad/left");
        }
    }
}
