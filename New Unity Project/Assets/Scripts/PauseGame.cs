using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public bool isPaused = false;

    public AudioSource music;

    public GameObject pauseMenu;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (isPaused == false)
            {
                Time.timeScale = 0;
                isPaused = true;
                Cursor.visible = true;
                music.Pause();
                pauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                isPaused = false;
                Cursor.visible = false;
                music.UnPause();
                pauseMenu.SetActive(false);
            }
        }
    }
}
