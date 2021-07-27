using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkTimer : MonoBehaviour
{
    public GameObject floor1;
    public GameObject floor2;
    public GameObject floor3;

    void Update()
    {
        if (floor1.activeSelf == true)
        {
            StartCoroutine(ActiveOff());
        }
        if (floor1.activeSelf == false)
        {
            StartCoroutine(ActiveOn());
        }
    }

    IEnumerator ActiveOff()
    {
        yield return new WaitForSeconds(3);
        floor1.SetActive(false);
        floor2.SetActive(false);
        floor3.SetActive(false);
    }

    IEnumerator ActiveOn()
    {
        yield return new WaitForSeconds(3);
        floor1.SetActive(true);
        floor2.SetActive(true);
        floor3.SetActive(true);
    }
}
