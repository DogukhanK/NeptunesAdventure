using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    public GameObject score;
    public GameObject score2;
    public static int currentScore;
    public int displayScore;

    void Start()
    {
        currentScore = 0;
    }
    void Update()
    {
        displayScore = currentScore;                           //get score value from gem script
        score.GetComponent<Text>().text = "" + displayScore;   //give value to UI 
        score2.GetComponent<Text>().text = "" + displayScore;
    }
}
