using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    private Queue<string> dialogueText;

    public Text name;
    public Text uiDialogue;

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

        string sentence = dialogueText.Dequeue();
        uiDialogue.text = sentence;
    }

    private void EndDialogue()
    {
        Debug.Log("end");
    }
}

