using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    public GameObject music;
    public GameObject levelTimer;
    public GameObject endTime;
    public GameObject endTime2;
    public GameObject endScore;
    public GameObject endScore2;
    public GameObject totalScore;
    public GameObject totalScore2;

    public int calculateFinalScore;
    public int finalScore;

    public AudioSource levelWin;
    public AudioSource levelWin2;

    public static bool winCondition;

    void OnTriggerEnter()
    {
        endTime.GetComponent<Text>().text = "Time: " + Timer.seconds;
        endTime2.GetComponent<Text>().text = "Time: " + Timer.seconds;
        calculateFinalScore = UpdateScore.displayScore * UpdateScore.gemsCollected;
        endScore.GetComponent<Text>().text = "Score: " + UpdateScore.displayScore + "  xGems Collected";
        endScore2.GetComponent<Text>().text = "Score: " + UpdateScore.displayScore + "  xGems Collected";
        finalScore = calculateFinalScore;
        totalScore.GetComponent<Text>().text = "Total Score: " + finalScore;
        totalScore2.GetComponent<Text>().text = "Total Score: " + finalScore;

        music.SetActive(false);
        levelTimer.SetActive(false);

        if (CharacterSelection.index == 0)
        {
            levelWin.Play();
        }
        if (CharacterSelection.index == 1)
        {
            levelWin2.Play();
        }

        winCondition = true;

        StartCoroutine(calculator());

        LevelSelection.isCompleted++;

        Cursor.visible = true;
    }

    IEnumerator calculator()
    {
        yield return new WaitForSeconds(0.5f);
        endTime.SetActive(true);
        endTime2.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        endScore.SetActive(true);
        endScore2.SetActive(true);
        yield return new WaitForSeconds(1.25f);
        totalScore.SetActive(true);
        totalScore2.SetActive(true);

    }
}
