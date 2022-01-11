using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunController : MonoBehaviour
{
    public int damage = -20;
    public int magazine = 6;
    private int currentClip;
    public int clip
    {
        get { return currentClip; }
    }


    public float reloadDelay = 3f;
    public float shootDelay = 1f;
    float rTimer;
    float sTimer;
    public bool canShoot = true;

    private GameObject Bullit;
    private GameObject Bullit1;
    private GameObject Bullit2;
    private GameObject Bullit3;
    private GameObject Bullit4;
    private GameObject Bullit5;

    // Start is called before the first frame update
    void Start()
    {
        currentClip = magazine;

        Bullit = GameObject.Find("Bullit");
        Bullit1 = GameObject.Find("Bullit (1)");
        Bullit2 = GameObject.Find("Bullit (2)");
        Bullit3 = GameObject.Find("Bullit (3)");
        Bullit4 = GameObject.Find("Bullit (4)");
        Bullit5 = GameObject.Find("Bullit (5)");
    }
    
    void FixedUpdate()
    {
        rTimer -= Time.deltaTime;
        Debug.Log(canShoot);
        if (rTimer < 0)
        {
            canShoot = true;
            rTimer = 0;
        }

        sTimer -= Time.deltaTime;
        if (sTimer < 0)
        {
            canShoot = true;
            sTimer = 0;
        }
    }

    public void Reload()
    {
        rTimer = reloadDelay;
        canShoot = false;
        currentClip = magazine;
        Bullit.active = true;
        Bullit1.active = true;
        Bullit2.active = true;
        Bullit3.active = true;
        Bullit4.active = true;
        Bullit5.active = true;
    }

    //hard code arduino magazine display
    public void ArduinoAmoController(int ArduinoClip)
    {
        switch (ArduinoClip)
        {
            case 0:
                Bullit.active = false;
                Bullit1.active = false;
                Bullit2.active = false;
                Bullit3.active = false;
                Bullit4.active = false;
                Bullit5.active = false;
                break;

            case 1:
                Bullit.active = true;
                Bullit1.active = false;
                Bullit2.active = false;
                Bullit3.active = false;
                Bullit4.active = false;
                Bullit5.active = false;
                break;

            case 2:
                Bullit.active = true;
                Bullit1.active = true;
                Bullit2.active = false;
                Bullit3.active = false;
                Bullit4.active = false;
                Bullit5.active = false;
                break;

            case 3:
                Bullit.active = true;
                Bullit1.active = true;
                Bullit2.active = true;
                Bullit3.active = false;
                Bullit4.active = false;
                Bullit5.active = false;
                break;

            case 4:
                Bullit.active = true;
                Bullit1.active = true;
                Bullit2.active = true;
                Bullit3.active = true;
                Bullit4.active = false;
                Bullit5.active = false;
                break;

            case 5:
                Bullit.active = true;
                Bullit1.active = true;
                Bullit2.active = true;
                Bullit3.active = true;
                Bullit4.active = true;
                Bullit5.active = false;
                break;

            case 6:
                Bullit.active = true;
                Bullit1.active = true;
                Bullit2.active = true;
                Bullit3.active = true;
                Bullit4.active = true;
                Bullit5.active = true;
                break;
        }
    }

    public void Shoot()
    {
        if (clip == 0)
        {
            Reload();
        }
        if (canShoot)
        {
            currentClip--;
            sTimer = shootDelay;
            canShoot = false;
            upDateUIgun();
        }
    }

    private void upDateUIgun()
    {
        if (clip == 5)
        {
            Bullit5.active = false;
        }
        if (clip == 4)
        {
            Bullit4.active = false;
        }
        if (clip == 3)
        {
            Bullit3.active = false;
        }
        if (clip == 2)
        {
            Bullit2.active = false;
        }
        if (clip == 1)
        {
            Bullit1.active = false;
        }
        if (clip == 0)
        {
            Bullit.active = false;
        }
    }
}
