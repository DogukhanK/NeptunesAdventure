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

    // Update is called once per frame
    void Update()
    {
        displayScore = currentScore;
        score.GetComponent<Text>().text = "" + displayScore;
        score2.GetComponent<Text>().text = "" + displayScore;
    }
}
