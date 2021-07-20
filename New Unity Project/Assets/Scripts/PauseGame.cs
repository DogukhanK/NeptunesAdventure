using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public bool isPaused = false;

    public AudioSource music;
    public AudioSource pauseAudio;
    public AudioSource pauseClickAudio;

    public GameObject pauseMenu;
    public GameObject audio;
    public GameObject audio2;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (isPaused == false)
            {
                pauseAudio.Play();
                audio.SetActive(false);
                audio2.SetActive(false);
                Time.timeScale = 0;
                isPaused = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                music.Pause();
                pauseMenu.SetActive(true);
            }
            else
            {
                audio.SetActive(true);
                audio2.SetActive(true);
                Time.timeScale = 1;
                isPaused = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                music.UnPause();
                pauseMenu.SetActive(false);
            }
        }
    }

    public void resumeLevel()
    {
        pauseClickAudio.Play();
        audio.SetActive(true);
        audio2.SetActive(true);
        Time.timeScale = 1;
        isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        music.UnPause();
        pauseMenu.SetActive(false);
    }

    public void restartLevel()
    {
        pauseClickAudio.Play();
        Time.timeScale = 1;
        isPaused = false;
        Cursor.visible = false;
        music.UnPause();
        pauseMenu.SetActive(false);
        SceneManager.LoadScene(4);
    }
    public void quitLevel()
    {
        pauseClickAudio.Play();
        Time.timeScale = 1;
        isPaused = false;
        Cursor.visible = false;
        music.UnPause();
        pauseMenu.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
