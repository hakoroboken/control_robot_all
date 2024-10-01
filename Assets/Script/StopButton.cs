using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StopButton : MonoBehaviour
{
    public bool stop;
    public TextMeshProUGUI _StopText;
    public OKButton _OKButton;
    public GameObject BackImage;
    [HideInInspector]
    public Image _backimage;
    public Sprite[] _back;
    public Transform redpos;
    public GameObject _circlered;

    // Start is called before the first frame update
    void Start()
    {
        stop = true;
        _StopText.text = "Stoped";
        _backimage = BackImage.GetComponent<Image>();
        _backimage.sprite = _back[0];
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Onclick()
    {
        if(stop == false)
        {
            GameObject red = (GameObject)Resources.Load("redcircle");
            GameObject redinstance = (GameObject)Instantiate(red, redpos.position, Quaternion.identity, _circlered.transform);
            _StopText.text = "Stoped";
            stop = true;
        }
    }
}
