using UnityEngine;

public class Lvl1Loader : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject zombie;
    public int normalZombies;
    public int zombieAmount() //sending zombie amount
    {
        return normalZombies;
    }

    void Start()
    {
        spawnZombie(normalZombies);
    }

    private void spawnZombie(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
            screenPosition.y = -2.45f;
            Instantiate(zombie, screenPosition, Quaternion.identity);
        }
    }
}
