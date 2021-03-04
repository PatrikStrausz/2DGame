using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI npcText;

    public TextMeshProUGUI goalName;
    public TextMeshProUGUI goalText;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
     
    }

  
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        
        string sentece =  sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentece));
      
    }

    IEnumerator TypeSentence(string sentece)
    {
        npcText.text = "";
        goalText.text = "";
        goalName.text = "Pinky";
        foreach(char letter in sentece.ToCharArray())
        {
            npcText.text += letter;
            goalText.text += letter;
            yield return null;
            FindObjectOfType<AudioManager>().Play("NPC");
        }

       
    }

    public void EndDialogue()
    {

        StartCoroutine(End());
    }


    public void Back()
    {

        npcText.text = "Oh you are back again";
        FindObjectOfType<AudioManager>().Play("NPC");
    }



    IEnumerator End()
    {
        npcText.text = "Bye";
        FindObjectOfType<AudioManager>().Play("NPC");
        yield return new WaitForSeconds(3);
        npcText.text = "";
       
    }
   

}
