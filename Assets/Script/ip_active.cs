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
    public GameObject _buttonObj1;
    public GameObject _buttonObj2;
    public GameObject _buttonObj3;
    public GameObject _buttonObj4;

    private Image _ipimage;
    private Image _keyipimage;
    private Image _keyportimage;
    private Image _buttonimage1;
    private Image _buttonimage2;
    private Image _buttonimage3;
    private Image _buttonimage4;
    public Sprite[] _active;
    public Sprite[] _key;
    public Sprite[] _button;

    public UdpSend _udpsend;

    // Start is called before the first frame update
    void Start()
    {
        active = true;
        _ipimage = GetComponent<Image>();
        _keyipimage = _IPImage.GetComponent<Image>();
        _keyportimage = _PoetImage.GetComponent<Image>();
        _buttonimage1 = _buttonObj1.GetComponent<Image>();
        _buttonimage2 = _buttonObj2.GetComponent<Image>();
        _buttonimage3 = _buttonObj3.GetComponent<Image>();
        _buttonimage4 = _buttonObj4.GetComponent<Image>();
        _keyipimage.sprite = _key[0];
        _keyportimage.sprite = _key[0];
        _ipimage.sprite = _active[0];
        _buttonimage1.sprite = _button[0];
        _buttonimage2.sprite = _button[0];
        _buttonimage3.sprite = _button[0];
        _buttonimage4.sprite = _button[0];
    }

    // Update is called once per frame
    public void Onclick()
    {
        if(active == true && _udpsend._can == false)
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
            _buttonimage1.sprite = _button[1];
            _buttonimage2.sprite = _button[1];
            _buttonimage3.sprite = _button[1];
            _buttonimage4.sprite = _button[1];
        }
        else if(active == false)
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
            _buttonimage1.sprite = _button[0];
            _buttonimage2.sprite = _button[0];
            _buttonimage3.sprite = _button[0];
            _buttonimage4.sprite = _button[0];
        }
    }
}
