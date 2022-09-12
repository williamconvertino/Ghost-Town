using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]

public class DialogueObject : ScriptableObject
{
    // Start is called before the first frame update
    [SerializeField][TextArea] private string[] dialogue;

    public string[] Dialogue => dialogue;
}
