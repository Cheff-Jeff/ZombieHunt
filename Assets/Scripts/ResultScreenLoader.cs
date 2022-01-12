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
        ArduinoToUnity.closePort();
        SceneManager.LoadScene(0); // index invullen
    }

    public void restart()
    {
        ArduinoToUnity.closePort();
        SceneManager.LoadScene(0); //index invullen
    }

    public void continu() {
        ArduinoToUnity.closePort();
        SceneManager.LoadScene(0); // index invullen 
    }
}
