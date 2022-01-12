using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultScreenLoader : MonoBehaviour
{
    public TextMeshProUGUI TxtExp;
    void Start()
    {
        TxtExp.text = PlayerExp.Exp.ToString();
    }

    public void home()
    {
        if (!PlayerExp.PlayStyle)
        { 
            ArduinoToUnity.closePort();
        }
        SceneManager.LoadScene(0); // index invullen
    }

    public void restart()
    {
        if (!PlayerExp.PlayStyle)
        {
            ArduinoToUnity.closePort();
        }
        SceneManager.LoadScene(0); //index invullen
    }

    public void continu() {
        if (!PlayerExp.PlayStyle)
        {
            ArduinoToUnity.closePort();
        }
        SceneManager.LoadScene(0); // index invullen 
    }
}
