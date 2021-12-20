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
        SceneManager.LoadScene(0); // index invullen
    }

    public void restart()
    {
        SceneManager.LoadScene(0); //index invullen
    }

    public void continu() {
        SceneManager.LoadScene(0); // index invullen 
    }
}
