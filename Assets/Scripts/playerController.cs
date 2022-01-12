using UnityEngine.SceneManagement;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //for the retreaval of zombie amount
    Lvl1Loader loader;

    private int amountZombiesLeft;

    public string playerName;
    public int maxHP = 3;
    private int currentHP;
    public int HP {get {return currentHP;}}
    public bool isDead {get; private set;}
    public bool style {get; set;}
    public int totalExp { get; private set;}

    private GameObject hard;
    private GameObject hard1;
    private GameObject hard2;

    // Start is called before the first frame update
    void Start()
    {
        hard = GameObject.Find("Heath");
        hard1 = GameObject.Find("Heath (1)");
        hard2 = GameObject.Find("Heath (2)");
    }

    void Awake()
    {
        totalExp = 0;
        loader = GameObject.Find("LevelParent").GetComponent<Lvl1Loader>();
        amountZombiesLeft = loader.zombieAmount(); //gets the amount of zombies in the level
        Debug.Log(amountZombiesLeft);
        Cursor.visible = false;
        currentHP = maxHP;
        isDead = false;
    }

    void Update()
    {
        if (amountZombiesLeft == 0)
        {
            PlayerExp.Exp = totalExp;
            PlayerExp.PlayStyle = style;
            SceneManager.LoadScene("WinScene");
        }
    } 

    public void killZombie()
    {
        amountZombiesLeft--;
    }

    public void changeHealth(int amount)
    {
        if (!isDead)
        {
            currentHP = Mathf.Clamp(currentHP + amount, 0, maxHP);
            setHards();
            if (currentHP == 0)
            {
                isDead = true;
                PlayerExp.Exp = totalExp;
                PlayerExp.PlayStyle = style;
                SceneManager.LoadScene("LoseScene"); //loads lose scene when player has died   
            }
            Debug.Log("Speler HP " + currentHP);
        }
        else
        {
            Debug.Log("Dood");
        }
    }

    public void changeExp(int amount)
    {
        totalExp = totalExp + amount;
        Debug.Log("Speler XP" + totalExp);
    }

    private void setHards()
    {
        if (HP == 2)
        {
            hard2.active = false;
        }
        if (HP == 1)
        {
            hard1.active = false;
        }
        if (HP == 0)
        {
            hard.active = false;
        }
    }
}