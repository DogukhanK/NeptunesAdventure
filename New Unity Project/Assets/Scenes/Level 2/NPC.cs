using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    private Queue<string> dialogueText;

    public Text name;
    public Text uiDialogue;

    public GameObject continueButton;
    public GameObject acceptButton;
    public GameObject textBox;
    public GameObject oldText;

    public static int isMinigame = 0;


    void Start()
    {
        dialogueText = new Queue<string>();
    }

    public void startConversation(NPCDialogue dialogue)
    {
        name.text = dialogue.name;

        dialogueText.Clear();

        foreach (string sentence in dialogue.dialogueText)
        {
            dialogueText.Enqueue(sentence);
        }

        DisplayDialogue();
    }

    public void DisplayDialogue()
    {
        if (dialogueText.Count == 0)
        {
            EndDialogue();
            return;
        }

        if (dialogueText.Count == 1)
        {
            continueButton.SetActive(false);
            acceptButton.SetActive(true);
        }


        string sentence = dialogueText.Dequeue();
        uiDialogue.text = sentence;
    }

    private void EndDialogue()
    {
        Debug.Log("end");
    }

    public void acceptButtonClicked()
    {
        acceptButton.SetActive(false);
        oldText.SetActive(false);
        textBox.SetActive(true);
        SceneManager.LoadScene(10);
    }
}

