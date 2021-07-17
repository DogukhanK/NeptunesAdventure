using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public static int currentLevelCode;
    public static int isCompleted = 1;

    public GameObject Level2Button;
    public GameObject Level3Button;
    public GameObject Level4Button;

    public AudioSource click;

    void Start()
    {
        if (isCompleted == 0)
        {
            Level2Button.SetActive(false);
            Level3Button.SetActive(false);
            Level4Button.SetActive(false);
        }

        if (isCompleted == 1)
        {
            Level3Button.SetActive(false);
            Level4Button.SetActive(false);
        }
        if (isCompleted == 2)
        {
            Level4Button.SetActive(false);
        }
        if (isCompleted == 3)
        {
            // nothing needed
        }

    }
    public void Level1()
    {
        click.Play();
        StartCoroutine(Level1Delay());
        currentLevelCode = 5;
    }

    public void Level2()
    {
        click.Play();
        StartCoroutine(Level2Delay());
        currentLevelCode = 6;
    }

    public void Level3()
    {
        click.Play();
        StartCoroutine(Level3Delay());
        currentLevelCode = 7;
    }

    public void Level4()
    {
        click.Play();
        StartCoroutine(Level4Delay());
        currentLevelCode = 8;
    }

    IEnumerator Level1Delay()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);
    }

    IEnumerator Level2Delay()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);
    }

    IEnumerator Level3Delay()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);
    }

    IEnumerator Level4Delay()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);
    }
}
