//using UnityEngine;

//public class DialogueActivator : MonoBehaviour, IInteractable
//{
//    [SerializeField] private DialogueObject dialogueObject;

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        //if (collision.GetComponent<Collider>().GetType() == typeof(CircleCollider2D))
//        //{
//        //    if (collision.CompareTag("Ghost") && collision.TryGetComponent(out Ghost ghost))
//        //    {
//        //        ghost.Interactable = this;
//        //    }
//        //}

//        if (collision.CompareTag("Ghost") && collision.TryGetComponent(out Ghost ghost))
//        {
//            ghost.Interactable = this;
//        }
//    }

//    private void OnTriggerExit2D(Collider2D collision)
//    {
//        //if (collision.GetComponent<Collider>().GetType() == typeof(CircleCollider2D))
//        //{
//        //    if (collision.CompareTag("Ghost") && collision.TryGetComponent(out Ghost ghost))
//        //    {
//        //        if (ghost.Interactable is DialogueActivator dialogueActivator && dialogueActivator == this)
//        //        {
//        //            ghost.Interactable = null;
//        //        }
//        //    }
//        //}

//        if (collision.CompareTag("Ghost") && collision.TryGetComponent(out Ghost ghost))
//        {
//            if (ghost.Interactable is DialogueActivator dialogueActivator && dialogueActivator == this)
//            {
//                ghost.Interactable = null;
//            }
//        }
//    }

//    //public void Interact(Ghost ghost)
//    //{
//    //    ghost.DialogueUI.ShowDialogue(dialogueObject);
//    //}
//}
 
