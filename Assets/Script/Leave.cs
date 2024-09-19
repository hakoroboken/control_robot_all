using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Leave : MonoBehaviour
{
    public bool leave_bool;
    public StopButton _stopbutton;
    public TextMeshProUGUI _StopText;
    public Transform yellowpos;
    public GameObject _circleyellow;
    public UdpSend _udpsend;
    private Image _leavebuttonimage;
    public Sprite[] LeaveButtonimage;

    // Start is called before the first frame update
    void Start()
    {
        leave_bool = false;
        _leavebuttonimage = GetComponent<Image>();
        _leavebuttonimage.sprite = LeaveButtonimage[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void leaveUDP()
    {
        if (leave_bool == false && _stopbutton.stop == true && _udpsend._canleave == false && _udpsend._can == false)
        {
            _leavebuttonimage.sprite = LeaveButtonimage[1];
            leave_bool = true;
            GameObject yellow = (GameObject)Resources.Load("yellowcircle");
            GameObject yellowinstance = (GameObject)Instantiate(yellow, yellowpos.position, Quaternion.identity, _circleyellow.transform);
            _udpsend.OnDestroy();
            _StopText.text = "Leave";
            _StopText.color = new Color(1.0f, 0.8f, 0.1f, 1.0f);
        }
        else if (leave_bool == true)
        {
            _leavebuttonimage.sprite = LeaveButtonimage[0];
            leave_bool = false;
            GameObject red = (GameObject)Resources.Load("redcircle");
            GameObject redinstance = (GameObject)Instantiate(red, yellowpos.position, Quaternion.identity, _circleyellow.transform);
            _udpsend.OnConnect();
            _StopText.text = "Stoped";
            _StopText.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
    }
}
