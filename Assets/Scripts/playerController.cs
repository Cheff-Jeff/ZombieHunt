
using UnityEngine;

public class playerController : MonoBehaviour
{
    public string playerName;
    public int maxHP = 3;
    private int currentHP;
    public int HP {get {return currentHP;}}
    public bool isDead {get; private set;}

    private int totalExp = 0;

    // Start is called before the first frame update
    void Awake()
    {
        Cursor.visible = false;
        currentHP = maxHP;
        isDead = false;
    }

    // Update is called once per frame
    void Update(){}

    public void changeHealth(int amount)
    {
        if (!isDead)
        {
            currentHP = Mathf.Clamp(currentHP + amount, 0, maxHP);
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

    public void changeExp(int amount)
    {
        totalExp = totalExp + amount;
        Debug.Log("Speler XP" + totalExp);
    }
}
