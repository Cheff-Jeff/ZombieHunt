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

    public float reloadDelay = 2f;
    public float shootDelay = 1f;

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

    public void Reload()
    {
        currentClip = magazine;
        Bullit.active = true;
        Bullit1.active = true;
        Bullit2.active = true;
        Bullit3.active = true;
        Bullit4.active = true;
        Bullit5.active = true;
    }

    void OnMouseDown()
    {
        Shoot();
    }

    public void Shoot()
    {
        if (clip == 0)
        {
            Reload();
        }

        currentClip--;
        upDateUIgun();
        Debug.Log("clip "+currentClip);
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
