using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1Loader : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject zombie;
    public int normalZombies;

    void Start()
    {
        spawnZombie(normalZombies);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnZombie(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
            Instantiate(zombie, screenPosition, Quaternion.identity);
        }
    }
}
