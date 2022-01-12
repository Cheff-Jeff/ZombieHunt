using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ResultScreenLoader : MonoBehaviour
{
    public TextMeshProUGUI TxtExp;
    public TextMeshProUGUI PlayerName;
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
        SceneManager.LoadScene(2); //index invullen
    }

    public void continu() {
        if (!PlayerExp.PlayStyle)
        {
            ArduinoToUnity.closePort();
        }

        if (PlayerName.text == "" || PlayerName.text == " ")
        {
            PlayerName.text = "Unknown walker";
        }

        StartCoroutine(PostData_Coroutine());

        IEnumerator PostData_Coroutine()
        {
            string uri = "http://192.168.1.70:3000/sendscore";
            WWWForm form = new WWWForm();
            form.AddField("name", PlayerName.text);
            form.AddField("score", PlayerExp.Exp.ToString());
            using (UnityWebRequest request = UnityWebRequest.Post(uri, form))
            {
                yield return request.SendWebRequest();
                if (request.isNetworkError || request.isHttpError)
                    Debug.Log(request.error);
                else
                    Debug.Log(request.downloadHandler.text);
            }
        }
        SceneManager.LoadScene(0); // index invullen 
    }
}
