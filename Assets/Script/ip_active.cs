using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ip_active : MonoBehaviour
{
    private bool active;
    public GameObject _IP;

    // Start is called before the first frame update
    void Start()
    {
        active = true;
    }

    // Update is called once per frame
    public void Onclick()
    {
        if(active == true)
        {
            _IP.SetActive(false);
            active = false;
        }
        else if(active == false)
        {
            _IP.SetActive(true);
            active = true;
        }
    }
}
