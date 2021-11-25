using System.IO.Ports;
using UnityEngine;

public class ArduinoToUnity : MonoBehaviour
{
    SerialPort sp;
    float lastMove;
    void Start()
    {
        string the_com = "";
        foreach (string mysps in SerialPort.GetPortNames())
        {
            print(mysps);
            if (mysps != "COM1") { the_com = mysps; break; }
        }
        sp = new SerialPort("\\\\.\\" + the_com, 115200);
        if (!sp.IsOpen)
        {
            sp.Open();
            sp.ReadTimeout = 50;
            sp.Handshake = Handshake.None;
            if (sp.IsOpen) { print("Open"); }
        }
    }

    // Update is called once per frame
    void Update()
    {
        string val = sp.ReadLine();
        float Move = float.Parse(val);
        transform.position = new Vector2(-1, Move);
        lastMove = Move;

    }
}
