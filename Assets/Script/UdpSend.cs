using UnityEngine;
using System.Net.Sockets;
using System.Text;
using TMPro;
using UnityEngine.UI;

public class UdpSend : MonoBehaviour
{
    private string host;
    private int IP1;
    private int IP2;
    private int IP3;
    private int IP4;
    private int port = 62455;
    private UdpClient client;

    //オブジェクトと結びつける
    public TextMeshProUGUI IPNumber;
    public TextMeshProUGUI PortNumber;
    public TextMeshProUGUI SendingMessage;
    public TMP_InputField IP_1_InputField;
    public TMP_InputField IP_2_InputField;
    public TMP_InputField IP_3_InputField;
    public TMP_InputField IP_4_InputField;
    public TMP_InputField Port_InputField;
    public CreateMessage _CreateMessage;
    public StopButton _StopButton;

    void Start()
    {
        IP1 = 192;
        IP2 = 168;
        IP3 = 10;
        IP4 = 123;
        host = IP1 + "." + IP2 + "." + IP3 +"." + IP4;
        IP_1_InputField.text = IP1.ToString();
        IP_2_InputField.text = IP2.ToString();
        IP_3_InputField.text = IP3.ToString();
        IP_4_InputField.text = IP4.ToString();
        IPNumber.text = host;
        Port_InputField.text = port.ToString();
        PortNumber.text = port.ToString();

        client = new UdpClient();
        client.Connect(host, port);

        #if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
        //WindowSizeAdjusterの付いたオブジェクトを生成し、DontDestroyOnLoadでシーンを跨いでも破棄されないように
        DontDestroyOnLoad(new GameObject("windowsize", typeof(windowsize)));
        #endif
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift))
        {
            if (IP_1_InputField.isFocused)
            {
                Port_InputField.ActivateInputField();
            }
            if (IP_2_InputField.isFocused)
            {
                IP_1_InputField.ActivateInputField();
            }
            if (IP_3_InputField.isFocused)
            {
                IP_2_InputField.ActivateInputField();
            }
            if (IP_4_InputField.isFocused)
            {
                IP_3_InputField.ActivateInputField();
            }
            if (Port_InputField.isFocused)
            {
                IP_4_InputField.ActivateInputField();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (IP_1_InputField.isFocused)
            {
                IP_2_InputField.ActivateInputField();
            }
            if (IP_2_InputField.isFocused)
            {
                IP_3_InputField.ActivateInputField();
            }
            if (IP_3_InputField.isFocused)
            {
                IP_4_InputField.ActivateInputField();
            }
            if (IP_4_InputField.isFocused)
            {
                Port_InputField.ActivateInputField();
            }
            if (Port_InputField.isFocused)
            {
                IP_1_InputField.ActivateInputField();
            }
        }

        SendingMessage.text = _CreateMessage.log;
        if (_StopButton.stop == true)
        {
            _CreateMessage.log = "s,0.500,0.500,0.500,0,0,0,e";
        }
        var message = Encoding.UTF8.GetBytes(_CreateMessage.log);
        Debug.Log(_CreateMessage.log);
        client.Send(message, message.Length);
    }

    private void OnDestroy()
    {
        client.Close();
    }

    public void SetText()
    {
        if(IP_1_InputField.text == "" || int.Parse(IP_1_InputField.text) >= 255 || int.Parse(IP_1_InputField.text) == 0)
        {
            IP_1_InputField.text = IP1.ToString();
        }
        if(IP_2_InputField.text == "" || int.Parse(IP_2_InputField.text) >= 255 || int.Parse(IP_2_InputField.text) == 0)
        {
            IP_2_InputField.text = IP2.ToString();
        }
        if(IP_3_InputField.text == "" || int.Parse(IP_3_InputField.text) >= 255 || int.Parse(IP_3_InputField.text) == 0)
        {
            IP_3_InputField.text = IP3.ToString();
        }
        if(IP_4_InputField.text == "" || int.Parse(IP_4_InputField.text) >= 255 || int.Parse(IP_4_InputField.text) == 0)
        {
            IP_4_InputField.text = IP4.ToString();
        }

        IP1 = int.Parse(IP_1_InputField.text);
        IP2 = int.Parse(IP_2_InputField.text);
        IP3 = int.Parse(IP_3_InputField.text);
        IP4 = int.Parse(IP_4_InputField.text);
        host = IP1 + "." + IP2 + "." + IP3 + "." + IP4;
        IPNumber.text = host;
        port = int.Parse(Port_InputField.text);
        PortNumber.text = port.ToString();

        client = new UdpClient();
        client.Connect(host, port);
    }
}