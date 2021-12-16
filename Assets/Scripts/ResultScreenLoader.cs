using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultScreenLoader : MonoBehaviour
{

    playerController Player;
    TextMesh Xp;
    public GameObject playerSats;
    //Start is called before the first frame update
    void Awake()
    {
        //Player = GameObject.Find("CrossHair").GetComponent<playerController>();
        Xp = GameObject.Find("ExpValue").GetComponent<TextMesh>();
        playerSats = GameObject.Find("PlayerStatsHolder");
        PlayerExp playerExp = playerSats.GetComponent<PlayerExp>();
        //Debug.Log(playerExp.EndExp);
        //Xp.text = Player.totalExp.ToString();
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
