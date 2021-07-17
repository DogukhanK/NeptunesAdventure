using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFadeIn : MonoBehaviour
{
    public GameObject fadeIn;

    void Start()
    {
        StartCoroutine(switchOff());
    }

    IEnumerator switchOff()
    {
        yield return new WaitForSeconds(1.2f);
        fadeIn.SetActive(false);
    }
}
