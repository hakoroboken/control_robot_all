using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StopButton : MonoBehaviour
{
    public bool stop;
    public TextMeshProUGUI _StopText;

    // Start is called before the first frame update
    void Start()
    {
        stop = true;
        _StopText.text = "Stoped";
    }

    public void Onclick()
    {
        stop = true;
        _StopText.text = "Stoped";
    }
}
