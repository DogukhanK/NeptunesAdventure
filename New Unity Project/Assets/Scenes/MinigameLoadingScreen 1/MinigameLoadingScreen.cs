using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MinigameLoadingScreen : MonoBehaviour
{
    public Slider loadingBar;
    public Text percentage;

    void Start()
    {
        StartCoroutine(loadingMinigameLevel());
    }

    IEnumerator loadingMinigameLevel()
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync(9);

        while (!loading.isDone)
        {
            float progress = Mathf.Clamp01(loading.progress / 0.9f);

            loadingBar.value = progress;
            percentage.text = progress * 100.0f + "%";

            yield return null;
        }
    }
}
