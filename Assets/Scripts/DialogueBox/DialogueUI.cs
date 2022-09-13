using TMPro;
using UnityEngine;
using System.Collections;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;

    //[SerializeField] private DialogueObject testDialogue;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private DialogueObject dialogueObject; 
    

    public bool IsOpen { get; set; }

    private TypewriterEffect typewriterEffect;

    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        IsOpen = false; 
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
        else if (!IsOpen)
        {
            dialogueBox.SetActive(false);
            textLabel.text = string.Empty;
        }
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        foreach (string dialogue in dialogueObject.Dialogue)
        {
            yield return typewriterEffect.Run(dialogue, textLabel);

            //presses space
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E)); 
        }

        IsOpen = false; 
    }


    //public void ShowDialogue(DialogueObject dialogueObject)
    //{
    //    if (IsOpen)
    //    {
    //        dialogueBox.SetActive(true);
    //        StartCoroutine(StepThroughDialogue(dialogueObject));
    //    }

    //}

    //private void CloseDialogueBox()
    //{

    //    dialogueBox.SetActive(false);
    //    textLabel.text = string.Empty;
    //}
}
