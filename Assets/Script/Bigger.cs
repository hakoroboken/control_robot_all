using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bigger : MonoBehaviour
{
    private int biggercount;
    private bool _stop;
    private bool _leave;
    private StopButton _StopButton;
    private Leave _leavebutton;

    // Start is called before the first frame update
    void Start()
    {
        GameObject StopButton = GameObject.Find("StopButton");
        _StopButton = StopButton.GetComponent<StopButton>();
        GameObject LeaveButton = GameObject.Find("LeaveButton");
        _leavebutton = LeaveButton.GetComponent<Leave>();
        biggercount = 0;
        if(_leavebutton.leave_bool == true)
        {
            _leave = true;
        }
        else if(_leavebutton.leave_bool == false)
        {
            _leave = false;
        }
        if(_StopButton.stop == true)
        {
            _stop = true;
        }
        else if(_StopButton.stop == false)
        { 
            _stop = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        biggercount++;
        this.transform.localScale = new Vector3(1, 1, 1) * biggercount * 0.8f;
        if(biggercount > 600)
        {
            if(_leave == true)
            {
                _StopButton._backimage.sprite = _StopButton._back[2];
            }
            else if(_stop == true)
            {
                _StopButton._backimage.sprite = _StopButton._back[0];
            }
            else if (_stop == false)
            {
                _StopButton._backimage.sprite = _StopButton._back[1];
            }
            Destroy(this.gameObject);
        }
    }
}
