using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject music;
    public GameObject levelTimer;
    public AudioSource levelWin;
    public static bool winCondition;

    void OnTriggerEnter()
    {
        music.SetActive(false);
        levelTimer.SetActive(false);
        levelWin.Play();
        winCondition = true;
    }
}
