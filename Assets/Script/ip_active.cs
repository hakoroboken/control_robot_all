using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ip_active : MonoBehaviour
{
    private bool active;
    public GameObject _IP;

    private Image _ipimage;
    public Sprite[] _active;

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
            _IP.SetActive(false);
            active = false;
            _ipimage.sprite = _active[1];
        }
        else if(active == false)
        {
            _IP.SetActive(true);
            active = true;
            _ipimage.sprite = _active[0];
        }
    }
}
