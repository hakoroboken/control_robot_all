using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ip_active : MonoBehaviour
{
    public bool active;
    public TMP_InputField _Port;
    public TMP_InputField _IP1;
    public TMP_InputField _IP2;
    public TMP_InputField _IP3;
    public TMP_InputField _IP4;
    public TMP_Dropdown _Mode;

    public GameObject _PoetImage;
    public GameObject _IPImage;
    public GameObject _buttonObj1;
    public GameObject _buttonObj2;
    public GameObject _buttonObj3;
    public GameObject _buttonObj4;

    private Image _keyipimage;
    private Image _keyportimage;
    private Image _buttonimage1;
    private Image _buttonimage2;
    private Image _buttonimage3;
    private Image _buttonimage4;
    public Sprite[] _key;
    public Sprite[] _button;

    // Start is called before the first frame update
    void Start()
    {
        active = true;
        _ipimage = GetComponent<Image>();
        _ipimage.sprite = _active[0];
    }

    // Update is called once per frame
    public void Onclick()
    {
        if(active == true)
        {
            _Port.interactable = false;
            _IP1.interactable = false;
            _IP2.interactable = false;
            _IP3.interactable = false;
            _IP4.interactable = false;
            _Mode.interactable = false;
            active = false;
            _ipimage.sprite = _active[1];
        }
        else if(active == false)
        {
            _Port.interactable= true;
            _IP1.interactable= true;
            _IP2.interactable= true;
            _IP3.interactable= true;
            _IP4.interactable= true;
            _Mode.interactable = true;
            active = true;
            _ipimage.sprite = _active[0];
        }
    }
}
