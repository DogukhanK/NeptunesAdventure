using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    private GameObject[] characterList;

    public static int index = 0;

    public AudioSource Neptune;
    public AudioSource Neptune2;
    public AudioSource click;

    void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");

        characterList = new GameObject[transform.childCount];       //add players into an array

        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;    //fill the array with the player prefabs
        }

        foreach (GameObject go in characterList)
         {
             go.SetActive(false);                                //set invisible
         }
         if (characterList[index])
         {
             characterList[index].SetActive(true);
         }
        
    }

    public void Left()
    {
        characterList[index].SetActive(false);

        click.Play();

        index--;

        if (index < 0)
        {
            index = characterList.Length - 1;
        }

        characterList[index].SetActive(true);
    }

    public void Right()
    {
        characterList[index].SetActive(false);

        click.Play();

        index++;

        if (index == characterList.Length)
        {
            index = 0;
        }

        characterList[index].SetActive(true);
    }

    public void Confirm()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);

        if (index == 0)
        {
            Neptune.Play();
            StartCoroutine(StartDelay());
        }

        if (index == 1)
        {
            Neptune2.Play();
            StartCoroutine(StartDelay2());
        }
    }

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(3);
    }

    IEnumerator StartDelay2()
    {
        yield return new WaitForSeconds(1.6f);
        SceneManager.LoadScene(3);
    }
}
