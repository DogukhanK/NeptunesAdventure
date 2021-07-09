using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBox : MonoBehaviour
{
    public static float rotationSpeed = 0.8f;
    public GameObject lightDir;

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
        lightDir.transform.Rotate(0, -0.0025f, 0, Space.World);
    }
}
