using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject talkPrompt;
    public GameObject textBox;

    public NPCDialogue dialogue;

    void OnTriggerEnter()
    {
        talkPrompt.SetActive(true);
    }

    void OnTriggerStay()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Cursor.visible = true;
            Time.timeScale = 0;
            textBox.SetActive(true);
            triggerDialogue();
        }
    }

    public void triggerDialogue()
    {
        talkPrompt.SetActive(false);
        FindObjectOfType<NPC>().startConversation(dialogue);
    }
}
