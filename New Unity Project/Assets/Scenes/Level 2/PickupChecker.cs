using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupChecker : MonoBehaviour
{
    public GameObject tile;
    public GameObject tile2;
    public GameObject tile3;
    public GameObject tile4;

    public GameObject gem1;
    public GameObject gem2;
    public GameObject gem3;
    public GameObject gem4;

    public static int totalCollected = 0;

    public bool phase1 = true;
    public bool phase2 = false;
    public bool phase3 = false;
    public bool phase4 = false;
    public static bool isOn = false;

    void Update()
    {
        if (phase1)
        {
            isPickedUp();
        }
        if (phase2)
        {
            isPickedUp2();
        }
        if (phase3)
        {
            isPickedUp3();
        }
        if (phase4)
        {
            isPickedUp4();
        }
    }

    public void isPickedUp()
    {
        if (gem1 == null)
        {
            tile.GetComponent<Renderer>().material.color = Color.green;
            totalCollected = 1;
            gem2.SetActive(true);
            phase1 = false;
            phase2 = true;
        }
    }

    public void isPickedUp2()
    {
        if (gem2 == null)
        {
            tile2.GetComponent<Renderer>().material.color = Color.green;
            totalCollected = 2;
            gem3.SetActive(true);
            phase2 = false;
            phase3 = true;
        }
    }

    public void isPickedUp3()
    {
        if (gem3 == null)
        {
            tile3.GetComponent<Renderer>().material.color = Color.green;
            totalCollected = 3;
            gem4.SetActive(true);
            phase3 = false;
            phase4 = true;
        }
    }

    public void isPickedUp4()
    {
        if (gem4 == null)
        {
            tile4.GetComponent<Renderer>().material.color = Color.green;
            totalCollected = 4;
            phase4 = false;
            isOn = true;
            StartCoroutine(count());
        }
    }

    IEnumerator count()
    {
        yield return new WaitForSeconds(1);
        isOn = false;
    }
}
