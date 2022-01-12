using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditHandler : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GoHome();
        }
    }

    public void GoHome()
    {
        SceneManager.LoadScene(0);
    }
}
