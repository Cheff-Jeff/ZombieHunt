using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader1 : MonoBehaviour
{
    public GameObject LevelLoader;
    public Slider slider;
    public int levelIndex = 2;
    public Text txtProgress;

    void Start()
    {
        LoadLevel(levelIndex);
    }

    public void LoadLevel(int index)
    {
        StartCoroutine(LoadAsynchronously(index));
    }

    IEnumerator LoadAsynchronously(int index)
    { 
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);

        LevelLoader.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            txtProgress.text = progress * 100 + "%";
            yield return null;//wait 1 fraim
        }
    }
}
