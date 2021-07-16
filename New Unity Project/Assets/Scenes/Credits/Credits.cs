using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(creditDelay());
    }

    IEnumerator creditDelay()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(0);
    }
}
