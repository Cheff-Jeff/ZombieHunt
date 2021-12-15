
using UnityEngine;

public class playerController : MonoBehaviour
{
    public string playerName;
    public int maxHP = 3;
    private int currentHP;
    public int HP {get {return currentHP;}}
    public bool isDead {get; private set;}

    private int totalExp = 0;

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
        Cursor.visible = false;
        currentHP = maxHP;
        isDead = false;
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
            }
            Debug.Log("Speler HP " + currentHP);
        }
        else
        {
            Debug.Log("Dood");
        }
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

    public void changeExp(int amount)
    {
        totalExp = totalExp + amount;
        Debug.Log("Speler XP" + totalExp);
    }
}
