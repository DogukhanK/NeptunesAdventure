using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public GameObject death;
    public GameObject music;
    public GameObject fadeOut;
    public AudioSource deathAudio;

    void OnTriggerEnter()
    {
        StartCoroutine (died());
    }

    IEnumerator died()
    {
        death.SetActive(true);
        music.SetActive(false);
        deathAudio.Play();
        yield return new WaitForSeconds(1);
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(4);
    }
}
