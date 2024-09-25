using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static System.Collections.Specialized.BitVector32;

public class input_manager : MonoBehaviour
{
    [SerializeField] public CreateMessage _createMassage;

    private GameInputs gameinput;

    private InputAction mec1plusAction;
    private InputAction mec1minusAction;
    private InputAction mec2plusAction;
    private InputAction mec2minusAction;
    private InputAction mec3plusAction;
    private InputAction mec3minusAction;

    private int now_config;

    void Start()
    {
        gameinput = _createMassage._gameInputs;

        mec1plusAction = gameinput.Player.Mec1_plus;
        mec1minusAction = gameinput.Player.Mec1_minus;
        mec2plusAction = gameinput.Player.Mec2_plus;
        mec2minusAction = gameinput.Player.Mec2_minus;
        mec3plusAction = gameinput.Player.Mec3_plus;
        mec3minusAction = gameinput.Player.Mec3_minus;

        now_config = 0;
    }

    public void changekey_0()
    {
        mec1plusAction.ChangeBinding(1).WithPath("<Gamepad>/leftTrigger");
        mec1plusAction.ChangeBinding(2).WithPath("<Gamepad>/buttonWest");

        mec1minusAction.ChangeBinding(1).WithPath("<Gamepad>/rightTrigger");
        mec1minusAction.ChangeBinding(2).WithPath("<Gamepad>/buttonWest");

        mec2plusAction.ChangeBinding(1).WithPath("<Gamepad>/leftTrigger");
        mec2plusAction.ChangeBinding(2).WithPath("<Gamepad>/buttonNorth");

        mec2minusAction.ChangeBinding(1).WithPath("<Gamepad>/rightTrigger");
        mec2minusAction.ChangeBinding(2).WithPath("<Gamepad>/buttonNorth");

        mec3plusAction.ChangeBinding(1).WithPath("<Gamepad>/leftTrigger");
        mec3plusAction.ChangeBinding(2).WithPath("<Gamepad>/buttonEast");

        mec3minusAction.ChangeBinding(1).WithPath("<Gamepad>/rightTrigger");
        mec3minusAction.ChangeBinding(2).WithPath("<Gamepad>/buttonEast");

        now_config = 0;
    }

    public void changekey_1()
    {
        mec1plusAction.ChangeBinding(1).WithPath("<Gamepad>/dpad/left");
        mec1plusAction.ChangeBinding(2).WithPath("<Gamepad>/dpad/left");

        mec1minusAction.ChangeBinding(1).WithPath("<Gamepad>/buttonWest");
        mec1minusAction.ChangeBinding(2).WithPath("<Gamepad>/buttonWest");

        mec2plusAction.ChangeBinding(1).WithPath("<Gamepad>/dpad/up");
        mec2plusAction.ChangeBinding(2).WithPath("<Gamepad>/dpad/up");

        mec2minusAction.ChangeBinding(1).WithPath("<Gamepad>/buttonNorth");
        mec2minusAction.ChangeBinding(2).WithPath("<Gamepad>/buttonNorth");

        mec3plusAction.ChangeBinding(1).WithPath("<Gamepad>/dpad/right");
        mec3plusAction.ChangeBinding(2).WithPath("<Gamepad>/dpad/right");

        mec3minusAction.ChangeBinding(1).WithPath("<Gamepad>/buttonEast");
        mec3minusAction.ChangeBinding(2).WithPath("<Gamepad>/buttonEast");

        now_config = 1;
    }
}
