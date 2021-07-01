using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    Color[] colors = new Color[6];

    void Start()
    {
        colors[0] = Color.green;
        colors[1] = Color.blue;
        colors[2] = Color.cyan;
        colors[3] = Color.yellow;
        colors[4] = Color.white;
        colors[5] = Color.red;

        gameObject.GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
