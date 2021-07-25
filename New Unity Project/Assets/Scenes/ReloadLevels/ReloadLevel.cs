using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadLevel : MonoBehaviour
{
    public static int level = 5;

    void Update()
    {
        if (level == 5)
        {
            SceneManager.LoadScene(LevelSelection.currentLevelCode);
            Death.isDead = false;
        }
    }
}
