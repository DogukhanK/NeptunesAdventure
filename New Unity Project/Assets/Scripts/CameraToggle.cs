using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToggle : MonoBehaviour
{
    public GameObject camera;
    public GameObject camera2;

    void Start()
    {
        if (CharacterSelection.index == 1)
        {
            camera.SetActive(false);
        }
        if (CharacterSelection.index == 0)
        {
            camera2.SetActive(false);
        }
    }
}
