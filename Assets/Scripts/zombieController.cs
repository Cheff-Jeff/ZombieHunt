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

    public float maxSpeed = 5f;
    public float changeTime = 3.0f;
    float timer;
    int direction;

    public bool inRange = false;
    bool hit = false;

    // Start is called before the first frame update
    void Start()
    {
        Gun = GameObject.Find("CrossHair").GetComponent<gunController>();
        Player = GameObject.Find("CrossHair").GetComponent<playerController>();
        rb = GetComponent<Rigidbody2D>();
        currentHP = maxHP;
        timer = changeTime;
        direction = getRandomNum();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
        if (Input.GetMouseButtonDown(0) || ArduinoToUnity.getButtonState() == 1)
        {
            if (inRange)
            {
                changeHealth(Gun.damage);
            }
        }
        if (Player.isDead == false)
        {
            eatPlayer();
        }
    }

    void FixedUpdate()
    {
        if (!hit)
        {
            Vector2 position = rb.position;
            position.x = position.x + Time.deltaTime * maxSpeed * direction;
            rb.MovePosition(position);
        }
        else {
        
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        gunController gunCheck = collision.gameObject.GetComponent<gunController>();
        if (gunCheck != null)
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        gunController gunCheck = collision.gameObject.GetComponent<gunController>();
        if (gunCheck != null)
        {
            inRange = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (direction > 0)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
    }

    int getRandomNum()
    {
        bool correctValue = false;
        int num = 0;
        while (!correctValue)
        {
            num = Random.Range(-1, 1);
            if (num == -1 || num == 1)
            {
                correctValue = true;
            }
        }

        return num;
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
