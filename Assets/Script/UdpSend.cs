using UnityEngine;
using System.Net.Sockets;
using System.Text;
using TMPro;
using UnityEngine.UI;

public class UdpSend : MonoBehaviour
{
    public string host = "172.20.10.2";
    public int port = 9000;
    private UdpClient client;

    //オブジェクトと結びつける
    public TextMeshProUGUI IPNumber;
    public TextMeshProUGUI PortNumber;
    public TextMeshProUGUI SendingMessage;
    public TMP_InputField IP_InputField;
    public TMP_InputField Port_InputField;
    public PlayerMover _playerMover;

    void Start()
    {
        IP_InputField.text = host;
        IPNumber.text = host;
        Port_InputField.text = port.ToString();
        PortNumber.text = port.ToString();

        client = new UdpClient();
        client.Connect(host, port);
    }


    void Update()
    {
        SendingMessage.text = _playerMover.log;
        var message = Encoding.UTF8.GetBytes(_playerMover.log);
        Debug.Log(_playerMover.log);
        client.Send(message, message.Length);
    }

    private void OnDestroy()
    {
        client.Close();
    }

    public void SetText()
    {
        IPNumber.text = IP_InputField.text;
        host = IP_InputField.text;
        PortNumber.text = Port_InputField.text;
        port = int.Parse(Port_InputField.text);
    }
}