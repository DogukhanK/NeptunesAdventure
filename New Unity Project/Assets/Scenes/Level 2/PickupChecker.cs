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

    void Update()
    {
        isPickedUp();
    }

    public void isPickedUp()
    {
        if (gem1 == null)
        {
            tile.GetComponent<Renderer>().material.color = Color.green;
        }

        if (gem2 == null)
        {
            tile2.GetComponent<Renderer>().material.color = Color.green;
        }

        if (gem3 == null)
        {
            tile3.GetComponent<Renderer>().material.color = Color.green;
        }

        if (gem4 == null)
        {
            tile4.GetComponent<Renderer>().material.color = Color.green;
        }
    }

}
