﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{

    void OnTriggerEnter()
    {
        SceneManager.LoadScene(0);
    }
}
