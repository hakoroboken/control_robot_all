using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class OKButton : MonoBehaviour
{
    public int okcount;
    public StopButton _StopButton;
    public TextMeshProUGUI _StopText;
    public GameObject _greencircle;
    public GameObject _redcircle;
    private Vector3 okscale = new Vector3(1, 1, 1);

    // Start is called before the first frame update
    void Start()
    {
        _greencircle.transform.localScale = new Vector3(1, 1, 1);
        okcount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (okcount >= 1)
        {
            _greencircle.transform.localScale = okscale * okcount * 0.5f;
            okcount++;
            if (okcount >= 400)
            {
                okcount = 0;
                _redcircle.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    public void Onclick()
    {
        if(_StopButton.stop == true)
        {
            _StopText.text = "";
            okcount = 1;
            _StopButton.stop = false;
            _StopButton._backimage.sprite = _StopButton._back[1];
            _greencircle.transform.SetSiblingIndex(2);
        }
    }
}
