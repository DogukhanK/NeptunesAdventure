using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public static int level = 1;

    void Update()
    {
        if (level == 1)
        {
            SceneManager.LoadScene(level);
        }
    }
}
