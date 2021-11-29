using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class zombieController : MonoBehaviour
{
    public int maxHP = 100;
    private int currentHP;
    public int HP 
    { 
        get 
        { 
            return currentHP; 
        } 
    }
    private bool isDead = false;
    public int exp = 50;

    gunController Gun;
    playerController Player;

    // Start is called before the first frame update
    void Start()
    {
        Gun = GameObject.Find("CrossHair").GetComponent<gunController>();
        Player = GameObject.Find("CrossHair").GetComponent<playerController>();
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeHealth(int amount)
    {
        //voor damage voeg minwaarde toe.
        if (!isDead)
        {
            currentHP = Mathf.Clamp(currentHP + amount, 0, maxHP);
            if (currentHP == 0)
            {
                isDead = true;
                die();
            }
            Debug.Log(currentHP);
        }
    }

    private void OnMouseDown()
    {
        getShot();
    }

    //click
    public void getShot()
    {
        int damage = Gun.Shoot();

        changeHealth(damage);
    }

    public void eatPlayer()
    {
        Player.changeHealth(-1);
    }

    public void die()
    {
        Player.changeExp(exp);
    }
}
