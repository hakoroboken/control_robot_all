using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StopButton : MonoBehaviour
{
    public bool stop;
    public int stopcount;
    public TextMeshProUGUI _StopText;
    public OKButton _OKButton;
    public GameObject _redcircle;
    public GameObject _greencircle;
    private Vector3 stopscale = new Vector3(1, 1, 1);
    public GameObject BackImage;
    [HideInInspector]
    public Image _backimage;
    public Sprite[] _back;

    // Start is called before the first frame update
    void Start()
    {
        stop = true;
        _StopText.text = "Stoped";
        _redcircle.transform.localScale = new Vector3(1,1,1);
        stopcount = 0;
        _backimage = BackImage.GetComponent<Image>();
        _backimage.sprite = _back[0];
        _redcircle.transform.localScale = stopscale * 79.8f;
    }

    // Update is called once per frame
    void Update()
    {
        if(stopcount >= 1)
        {
            _redcircle.transform.localScale = stopscale * stopcount * 0.4f;
            stopcount++;
            if(stopcount >= 400) { 
                stopcount = 0;
                _greencircle.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

        public void Onclick()
    {
        if(stop == false)
        {
            _StopText.text = "Stoped";
            stopcount = 1;
            stop = true;
            _redcircle.transform.SetSiblingIndex(2);
            _backimage.sprite = _back[1];
        }
    }
}
