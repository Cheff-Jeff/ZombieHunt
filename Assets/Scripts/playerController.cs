using System.Collections;
using System.Collections.Generic;
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
    void Start()
    {
        Cursor.visible = false;
        currentHP = maxHP;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseCursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouseCursorPos;
    }

    public void changeHealth(int amount)
    {
        if (!isDead)
        {
            currentHP = Mathf.Clamp(currentHP + amount, 0, maxHP);
            if (currentHP == 0)
            {
                isDead = true;
            }
            Debug.Log(currentHP);
        }
        else
        {
            Debug.Log("Dood");
        }
    }

    public void changeExp(int amount)
    {
        totalExp = totalExp + amount;
        Debug.Log("Hier");
        Debug.Log(totalExp);
    }
}
