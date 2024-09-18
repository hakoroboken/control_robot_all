using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.UIElements;

public class OKButton : MonoBehaviour
{
    public StopButton _StopButton;
    public TextMeshProUGUI _StopText;
    public Transform greenpos;
    public GameObject _circlegreen;
    public UdpSend _UdpSend;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Onclick()
    {
        if(_StopButton.stop == true && _UdpSend._can == false)
        {
            GameObject green = (GameObject)Resources.Load("greencircle");
            GameObject greeninstance = (GameObject)Instantiate(green, greenpos.position, Quaternion.identity, _circlegreen.transform);
            _StopText.text = "Sending";
            _StopText.color = new Color(0.0f, 0.796f, 0.0f, 1.0f);
            _StopButton.stop = false;
        }
    }
}
