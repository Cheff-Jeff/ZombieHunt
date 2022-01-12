using System.IO.Ports;
using UnityEngine;

public class ArduinoToUnity : MonoBehaviour
{
    static SerialPort sp;
    static int ButtonState;
    static int arduinoAmoCount;

    void Start()
    {
        openPort();
    }

    static public void openPort()
    {
        string the_com = "";
        foreach (string mysps in SerialPort.GetPortNames())
        {
            print(mysps);
            if (mysps != "COM1" && mysps != "COM4" && mysps != "COM5") { the_com = mysps; break; }
        }
        sp = new SerialPort("\\\\.\\" + the_com, 9600);
        if (!sp.IsOpen)
        {
            print("Opening " + the_com + ", baud 9600");
            sp.Open();
            sp.ReadTimeout = 100;
            sp.Handshake = Handshake.None;
        }
    }

    static public void closePort()
    {
        if (sp.IsOpen)
        {
            sp.Close();
        }
    }


    public static int getButtonState()
    {
        return ButtonState;
    }

    public static int getArduinoMagazine()
    {
        return arduinoAmoCount;
    }

    // Update is called once per frame
    void Update()
    {
        string val = sp.ReadLine();
        string[] Move = val.Split(',');
        if (Move[0] != "" && Move[1] != "" && Move[2] != "" && Move[3] != "")
        {
            Debug.Log("Run");
            Vector2 rot = new Vector2(float.Parse(Move[1]), float.Parse(Move[0]));
            ButtonState = int.Parse(Move[2]);
            arduinoAmoCount = int.Parse(Move[3]);

            transform.position = rot;
        }


    }
}

