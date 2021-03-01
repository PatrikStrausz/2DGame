using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI npcText;

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
        Debug.Log(sentece);
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentece));
      
    }

    IEnumerator TypeSentence(string sentece)
    {
        npcText.text = "";
        foreach(char letter in sentece.ToCharArray())
        {
            npcText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {

        StartCoroutine(End());
    }


    public void Back()
    {

        npcText.text = "Oh you are back again";
    }



    IEnumerator End()
    {
        npcText.text = "Bye";
        yield return new WaitForSeconds(3);
        npcText.text = "";
    }
   

}
