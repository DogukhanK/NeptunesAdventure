using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    private GameObject[] characterList;

    private int index = 0;

    void Start()
    {
        characterList = new GameObject[transform.childCount];       //add players into an array

        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;    //fill the array with the player prefabs
        }

        foreach (GameObject go in characterList)
         {
             go.SetActive(false);                                //set invisible
         }
         if (characterList[0])
         {
             characterList[0].SetActive(true);
         }
        
    }

    public void Left()
    {
        characterList[index].SetActive(false);

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

        index++;

        if (index == characterList.Length)
        {
            index = 0;
        }

        characterList[index].SetActive(true);
    }

    public void Confirm()
    {
        SceneManager.LoadScene(3);
    }
}
