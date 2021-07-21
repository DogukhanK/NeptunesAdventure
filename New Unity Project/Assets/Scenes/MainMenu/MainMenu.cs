using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuScreen;
    public GameObject OptionsMenuScreen;

    public AudioSource click;

    void Start()
    {
        Cursor.visible = true;
    }

    public void StartGame()
    {
        click.Play();
        StartCoroutine(SceneDelay());
    }

    public void Options()
    {
        click.Play();
        StartCoroutine(OptionsDelay());
    }

    public void Return()
    {
        click.Play();
        StartCoroutine(ReturnDelay());
    }

    public void Quit()
    {
        click.Play();
        StartCoroutine(QuitDelay());
    }

    IEnumerator SceneDelay()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }

    IEnumerator OptionsDelay()
    {
        yield return new WaitForSeconds(0.5f);
        MainMenuScreen.SetActive(false);
        OptionsMenuScreen.SetActive(true);
    }

    IEnumerator ReturnDelay()
    {
        yield return new WaitForSeconds(0.5f);
        MainMenuScreen.SetActive(true);
        OptionsMenuScreen.SetActive(false);
    }

    IEnumerator QuitDelay()
    {
        yield return new WaitForSeconds(1);
        Application.Quit();
    }
}
