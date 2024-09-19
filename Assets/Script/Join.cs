using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Join : MonoBehaviour
{
    public GameObject _mask;
    public GameObject _back;
    public UdpSend _UdpSend;
    public ip_active _ip_Active;

    public bool _canjoin; 

    // Start is called before the first frame update
    void Start()
    {
        _canjoin = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Onclick()
    {
        if(_UdpSend._can == true && _canjoin == true)
        {
            _UdpSend._can = false;
            _mask.transform.DOLocalMove(new Vector3(-240f,-240f,0f), 1f).OnComplete(() =>
            {
                this.gameObject.SetActive(false);
                _back.SetActive(false);
                _mask.SetActive(false);
            });
            _ip_Active.Onclick();
        }
    }
}
