using System.IO.Ports;
using UnityEngine;

public class ArduinoToUnity : MonoBehaviour
{
    SerialPort sp;
    static int ButtonState;

    void Start()
    {
        string the_com = "";
        foreach (string mysps in SerialPort.GetPortNames())
        {
            print(mysps);
            if (mysps != "COM1") { the_com = mysps; break; }
        }
        sp = new SerialPort("\\\\.\\" + the_com, 9600);
        if (!sp.IsOpen)
        {
            print("Opening " + the_com + ", baud 9600");
            sp.Open();
            sp.ReadTimeout = 50;
            sp.Handshake = Handshake.None;
            if (sp.IsOpen) { print("Open"); }
        }
    }

    public static int getButtonState()
    {
        return ButtonState;
    }

    // Update is called once per frame
    void Update()
    {
        string val = sp.ReadLine();
        string[] Move = val.Split(',');
        if (Move[0] != "" && Move[1] != "" && Move[2] != "")
        {
            Debug.Log("Run");
            Vector2 rot = new Vector2(float.Parse(Move[1]), float.Parse(Move[0]));
            ButtonState = int.Parse(Move[2]);

            transform.position = rot;
        }


    }
}

