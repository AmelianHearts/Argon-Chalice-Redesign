using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.UI
{
    public class DialogueTrigger : MonoBehaviour
    {

        public Dialogue dialogue;
        //[SerializeField] public DialogueManager manager;

        public void TriggerDialogue()
        {
            //Debug.Log("triggerDialogue()");
            FindObjectOfType<MetaGameController>().ToggleDialogue(true);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            
        }

    }
}