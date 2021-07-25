using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Endgame : MonoBehaviour
{
    public GameObject gems;
    public GameObject gameTimer;
    public GameObject gameTimer2;
    public bool isDecreasing = false;

    public static int seconds = 10;

    void Start()
    {
        gems.SetActive(true);

        gameTimer.SetActive(true);
        gameTimer2.SetActive(true);
    }

    void Update()
    {
        if (isDecreasing == false)
        {
            StartCoroutine(tick());
        }

        if (seconds == 0)
        {
            gameTimer.SetActive(false);
            gameTimer2.SetActive(false);
            gems.SetActive(false);
        }
    }

    IEnumerator tick()
    {
        isDecreasing = true;
        seconds -= 1;                                    // inc 1 second
        gameTimer.GetComponent<Text>().text = "" + seconds;  // display seconds on UI
        gameTimer2.GetComponent<Text>().text = "" + seconds;
        yield return new WaitForSeconds(1);              // 1 second delay before ticking again
        isDecreasing = false;
    }
}
