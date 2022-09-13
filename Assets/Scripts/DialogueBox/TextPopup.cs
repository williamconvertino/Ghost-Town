using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPopup: MonoBehaviour
{
    public DialogueUI dialogueUI;
    //public DialogueObject dialogueObject; 

    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.IsOpen = false; 
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueUI.IsOpen = true;

            //dialogueUI.ShowDialogue(dialogueObject); 
        }
        
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueUI.IsOpen = false; 
        }
    }
}
