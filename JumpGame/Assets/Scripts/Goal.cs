using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    public GameObject dialogueCanvas;


    public DialogueTrigger dialogueTrigger;
    public DialogueManager dialogueManager;

    private void Awake()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            dialogueCanvas.SetActive(true);
            TimerController.instance.EndTimer();
            dialogueTrigger.TriggerDialogue();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        dialogueCanvas.SetActive(false);
       
    }
}
