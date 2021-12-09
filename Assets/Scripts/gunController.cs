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

    public void Reload()
    {
        currentClip = magazine;
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
        Debug.Log("clip "+currentClip);
    }
}
