using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public static int currentLevelCode;

    public void Level1()
    {
        SceneManager.LoadScene(2);
        currentLevelCode = 5;
    }

    public void Level2()
    {
        SceneManager.LoadScene(2);
        currentLevelCode = 6;
    }
}
