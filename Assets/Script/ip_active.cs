using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ip_active : MonoBehaviour
{
    public bool active;
    public TMP_InputField _IP;
    public TMP_InputField _Port1;
    public TMP_InputField _Port2;
    public TMP_InputField _Port3;
    public TMP_InputField _Port4;

    public GameObject _PoetImage;
    public GameObject _IPImage;

    private Image _ipimage;
    public Sprite[] _active;
    private Image _keyipimage;
    private Image _keyportimage;
    public Sprite[] _key;

    public UdpSend _udpsend;

    // Start is called before the first frame update
    void Start()
    {
        _IP.interactable = false;
        _Port1.interactable = false;
        _Port2.interactable = false;
        _Port3.interactable = false;
        _Port4.interactable = false;
        active = false;
        _ipimage = GetComponent<Image>();
        _keyipimage = _IPImage.GetComponent<Image>();
        _keyportimage = _PoetImage.GetComponent<Image>();
        _keyipimage.sprite = _key[1];
        _keyportimage.sprite = _key[1];
        _ipimage.sprite = _active[1];
    }

    // Update is called once per frame
    public void Onclick()
    {
        if(active == true)
        {
            _IP.interactable = false;
            _Port1.interactable = false;
            _Port2.interactable = false;
            _Port3.interactable = false;
            _Port4.interactable = false;
            active = false;
            _keyipimage.sprite = _key[1];
            _keyportimage.sprite = _key[1];
            _ipimage.sprite = _active[1];
        }
        else if(active == false && _udpsend._can == false)
        {
            _IP.interactable= true;
            _Port1.interactable= true;
            _Port2.interactable= true;
            _Port3.interactable= true;
            _Port4.interactable= true;
            active = true;
            _keyipimage.sprite = _key[0];
            _keyportimage.sprite = _key[0];
            _ipimage.sprite = _active[0];
        }
    }
}
