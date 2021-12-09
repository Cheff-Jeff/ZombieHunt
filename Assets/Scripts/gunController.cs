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

    // Start is called before the first frame update
    void Start()
    {
        currentClip = magazine;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reload()
    {
        currentClip = magazine;
    }

    public int Shoot()
    {
        if (clip == 0)
        {
            Reload();
        }

        currentClip--;
        return damage;
    }
}
