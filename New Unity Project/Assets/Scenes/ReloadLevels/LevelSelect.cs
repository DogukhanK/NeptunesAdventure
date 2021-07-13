using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public static int level = 4;

    void Update()
    {
        if (level == 4)
        {
            SceneManager.LoadScene(level);
        }
    }
}
