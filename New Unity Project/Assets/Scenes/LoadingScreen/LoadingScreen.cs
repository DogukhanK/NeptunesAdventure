using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public Slider loadingBar;
    public Text percentage;

    void Start()
    {
        StartCoroutine(loadingLevel());
    }

    IEnumerator loadingLevel()
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync(LevelSelection.currentLevelCode);

        while (!loading.isDone)
        {
            float progress = Mathf.Clamp01(loading.progress / 0.9f);

            loadingBar.value = progress;
            percentage.text = progress * 100.0f + "%";

            yield return null;
        }
    }
}
