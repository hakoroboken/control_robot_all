using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OKButton : MonoBehaviour
{
    public StopButton _StopButton;
    public TextMeshProUGUI _StopText;

    public void Onclick()
    {
        _StopButton.stop = false;
        _StopText.text = "";
    }
}
