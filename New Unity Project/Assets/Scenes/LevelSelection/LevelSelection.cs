using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public static int currentLevelCode;
    public static int isCompleted = 0;
    public static int thisLevel;

    public GameObject Level2Button;
    public GameObject Level3Button;
    public GameObject Level4Button;

    public AudioSource click;

    public int bestScore;
    public int bestScore2;
    public int bestScore3;
    public int bestScore4;

    public GameObject bestscoreDisplay;
    public GameObject bestscoreDisplay2;
    public GameObject bestscoreDisplay3;
    public GameObject bestscoreDisplay4;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        bestScore = PlayerPrefs.GetInt("LevelScore");
        bestscoreDisplay.GetComponent<Text>().text = "Best Score = " + bestScore;

        bestScore2 = PlayerPrefs.GetInt("LevelScore2");
        bestscoreDisplay2.GetComponent<Text>().text = "Best Score = " + bestScore2;

        bestScore3 = PlayerPrefs.GetInt("LevelScore3");
        bestscoreDisplay3.GetComponent<Text>().text = "Best Score = " + bestScore3;

        bestScore4 = PlayerPrefs.GetInt("LevelScore4");
        bestscoreDisplay4.GetComponent<Text>().text = "Best Score = " + bestScore4;


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
        thisLevel = 1;
    }

    public void Level2()
    {
        click.Play();
        StartCoroutine(Level2Delay());
        currentLevelCode = 6;
        thisLevel = 2;
    }

    public void Level3()
    {
        click.Play();
        StartCoroutine(Level3Delay());
        currentLevelCode = 7;
        thisLevel = 3;
    }

    public void Level4()
    {
        click.Play();
        StartCoroutine(Level4Delay());
        currentLevelCode = 8;
        thisLevel = 4;
    }

    public void ResetScores()
    {
        click.Play();
        PlayerPrefs.SetInt("LevelScore", 0);
        bestscoreDisplay.GetComponent<Text>().text = "Best Score = " + bestScore;
        PlayerPrefs.SetInt("LevelScore2", 0);
        bestscoreDisplay2.GetComponent<Text>().text = "Best Score = " + bestScore2;
        PlayerPrefs.SetInt("LevelScore3", 0);
        bestscoreDisplay3.GetComponent<Text>().text = "Best Score = " + bestScore3;
        PlayerPrefs.SetInt("LevelScore4", 0);
        bestscoreDisplay4.GetComponent<Text>().text = "Best Score = " + bestScore4;

        if (isCompleted == 0)
        {
            SceneManager.LoadScene(1);
            Level2Button.SetActive(false);
            Level3Button.SetActive(false);
            Level4Button.SetActive(false);
        }

        if (isCompleted == 1)
        {
            SceneManager.LoadScene(1);
            Level3Button.SetActive(false);
            Level4Button.SetActive(false);
        }
        if (isCompleted == 2)
        {
            SceneManager.LoadScene(1);
            Level4Button.SetActive(false);
        }
        if (isCompleted >= 3)
        {
            SceneManager.LoadScene(1);
            Level2Button.SetActive(true);
            Level3Button.SetActive(true);
            Level4Button.SetActive(true);
        }
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
