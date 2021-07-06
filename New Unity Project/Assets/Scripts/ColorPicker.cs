using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    Color[] colors = new Color[2];

    void Start()
    {
        colors[0] = Color.green;
        colors[1] = Color.red;

        gameObject.GetComponent<Renderer>().material.color = colors[Random.Range(0, colors.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
