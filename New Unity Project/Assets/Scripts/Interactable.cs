using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public int tileX;
    public int tileZ;
    public Tilemap map;

    void OnMouseDown()
    {
        map.playerMovement(tileX, tileZ);
    }
}
