using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{

    public GameObject[] activators;

    public GameObject instructionText;

    private bool isCompleted = false;

    private GameObject player;

    private int current = 0;

    public GameObject lever;

    public void Activated(GameObject go)
    {
        int which;
        which = Which(go);

        if (which != current)
        {
            foreach (GameObject stone in activators)
            {
                stone.GetComponent<Renderer>().material.color = Color.white;
            }

            current = 0;

            return;
        }

        go.GetComponent<Renderer>().material.color = Color.green;

        current++;

        if (current == activators.Length)
        {
            if (!isCompleted)
            {
                isCompleted = true;

                instructionText.SetActive(false);

                if (lever)
                {
                    lever.SetActive(true);
                }
            }
        }
    }

    int Which(GameObject go)
    {
        for (int i = 0; i < activators.Length; i++)
        {
            if (activators[i] == go)
            {
                return i;
            }
        }

        return -1;
    }

    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter()
    {


        if (!isCompleted)
        {
            instructionText.SetActive(true);
        }
        else
        {
            instructionText.SetActive(false);
        }
    }

    private void OnTriggerExit()
    {
        instructionText.SetActive(false);
    }
}
