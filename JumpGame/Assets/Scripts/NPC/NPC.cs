using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;
    public DialogueManager dialogueManager;

    int countSeen = 0;
  
    void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

   
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            dialogueManager.DisplayNextSentence();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {


           

            countSeen += 1;

            if(countSeen > 1)
            {
                dialogueManager.Back();
            }
            else
            {
                dialogueTrigger.TriggerDialogue();


                
                
            }

          

            
        }
    }

    


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            dialogueManager.EndDialogue();
        }
    }

    


   
}
