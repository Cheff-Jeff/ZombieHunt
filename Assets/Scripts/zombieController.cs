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
    Rigidbody2D rb;
    zombieController zombie;

    public float time = 2f;
    public float maxSpeed = 5f;
    private Vector2 movement;
    private float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        Gun = GameObject.Find("CrossHair").GetComponent<gunController>();
        Player = GameObject.Find("CrossHair").GetComponent<playerController>();
        rb = GetComponent<Rigidbody2D>();
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            timeLeft += time;
        }
        if (Player.isDead == false)
        {
            eatPlayer();
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(movement * maxSpeed);
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
            Debug.Log("zombie HP" + currentHP);
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
        Destroy(gameObject);
    }
}
