using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bigger : MonoBehaviour
{
    private int biggercount;
    private bool _stop;
    private StopButton _StopButton;

    // Start is called before the first frame update
    void Start()
    {
        GameObject StopButton = GameObject.Find("StopButton");
        _StopButton = StopButton.GetComponent<StopButton>();
        biggercount = 0;
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
            if(_stop == true)
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
