using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource click;

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
        yield return new WaitForSeconds(1);
        //insert load options code
    }

    IEnumerator QuitDelay()
    {
        yield return new WaitForSeconds(1);
        Application.Quit();
    }
}
