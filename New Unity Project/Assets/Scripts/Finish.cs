using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public AudioSource levelWin;

    public static bool winCondition;

    void OnTriggerEnter()
    {
        music.SetActive(false);
        levelTimer.SetActive(false);
        levelWin.Play();
        winCondition = true;

        StartCoroutine(calculator());
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
