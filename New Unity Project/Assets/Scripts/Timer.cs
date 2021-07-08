using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject timer;
    public GameObject timer2;

    public int seconds = 0;
    public bool isIncreasing = false;

    void Update()
    {
        if (isIncreasing == false)
        {
            StartCoroutine(tick());
        }
    }

    IEnumerator tick()
    {
        isIncreasing = true;
        seconds += 1;                                    // inc 1 second
        timer.GetComponent<Text>().text = "" + seconds;  // display seconds on UI
        timer2.GetComponent<Text>().text = "" + seconds;
        yield return new WaitForSeconds(1);              // 1 second delay before ticking again
        isIncreasing = false;                            // restart coroutine / stops from running every frame in update()
    }
}
