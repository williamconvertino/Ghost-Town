using TMPro;
using UnityEngine;
using System.Collections;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;

    [SerializeField] private GameObject dialogueBox;

    //object for if it is not finished 
    //[SerializeField] private DialogueObject dialogueObjectLevelNotFinished;

    ////dialogue for if the game is finished 
    //[SerializeField] private DialogueObject dialogueObjectLevelFinished;

    [SerializeField] private DialogueObject dialogueObject; 

    public bool IsOpen { get; set; }

    //public bool levelNotCleared { get; set; }

    private TypewriterEffect typewriterEffect;

    private void Start()
    { 
        typewriterEffect = GetComponent<TypewriterEffect>();
        IsOpen = false;
        //levelNotCleared = true; 
        doDialogue(); 
    }

    public void Update()
    {
        doDialogue(); 
    }

    public void doDialogue()
    {
        if (IsOpen)
        {
            dialogueBox.SetActive(true);
            StartCoroutine(StepThroughDialogue(dialogueObject));

        }

        else
        {
            dialogueBox.SetActive(false);
            textLabel.text = string.Empty;
        }

        //if (IsOpen)
        //{
        //    if (levelNotCleared)
        //    {
        //        if (dialogueObjectLevelNotFinished != null)
        //        {
        //            dialogueBox.SetActive(true);
        //            StartCoroutine(StepThroughDialogue(dialogueObjectLevelNotFinished));
        //        }

        //    }
        //    else if (!levelNotCleared)
        //    {
        //        if (dialogueObjectLevelFinished != null)
        //        {
        //            dialogueBox.SetActive(true);
        //            StartCoroutine(StepThroughDialogue(dialogueObjectLevelFinished));
        //        }

        //    }

        //}
        //else
        //{
        //    dialogueBox.SetActive(false);
        //    textLabel.text = string.Empty;
        //}


    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
      
        foreach (string dialogue in dialogueObject.Dialogue)
        {
            yield return typewriterEffect.Run(dialogue, textLabel);

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E)); 
        }

        IsOpen = false; 
    }
}
