using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class zombieController : MonoBehaviour
{
    //The X positions of the path
    float pathLeft = 1;
    float pathRight = 1.75f;

    //timers for zombie
    float attackTimer;
    public float attackCooldown;
    float onPathSpeed;

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
    Transform trans;
    Renderer rend;

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
        trans = GetComponent<Transform>(); //transform for object size manipulation
        rend = GetComponent<Renderer>(); //to change layer order
        currentHP = maxHP;
        timer = changeTime;
        direction = getRandomNum();
        attackTimer = Time.time + Random.Range(5, 15);
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

        //if zombie is on path walk forward
        if (currentHP != maxHP || Time.time > attackTimer)
        {
            //make zombie go to path on hit or after a random time
            if (direction < 0 && rb.position.x < pathLeft)
            {
                direction *= -1;
            }
            else if (direction > 0 && rb.position.x > pathRight)
            {
                direction *= -1;
            }
            if (trans.position.x >= 1 && trans.position.x <= 1.75 && trans.localScale.x < 0.75f && Time.time > onPathSpeed||trans.localScale.x > 0.4 && trans.localScale.x < 0.75 && Time.time > onPathSpeed)
            {
                onPathSpeed = Time.time + 0.08f;
                direction = 0;
                rend.sortingOrder = 6;
                trans.localScale = new Vector2(trans.localScale.x * 1.05f, trans.localScale.y * 1.05f);
                rb.position = new Vector2(rb.position.x, rb.position.y * 1.02f);

            }
            
        }
        

        //check is zombie is close enough to damage player (checking for X size but Y is also possible)
        if (Player.isDead == false && trans.localScale.x > 0.75f && Time.time > attackCooldown)
        {
            direction = getRandomNum();
            //make zombie be able to walk to the left and rigth
            pathLeft = -6;
            pathRight = 6;
            eatPlayer();
            Debug.Log("Player hit");
            attackCooldown = Time.time + 5f; //cooldown van 5 seconden
        }
    }

    void FixedUpdate()
    {
        if (!hit)
        {
            //change direction if close to border (12)
            if (direction > 0 && trans.position.x > 12 || direction < 0 && trans.position.x < -12)
            {
                direction *= -1;
            }
            Vector2 position = rb.position;
            position.x = position.x + Time.deltaTime * maxSpeed * direction;
            rb.MovePosition(position);
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
        Player.killZombie();
        Destroy(gameObject);
    }
}
