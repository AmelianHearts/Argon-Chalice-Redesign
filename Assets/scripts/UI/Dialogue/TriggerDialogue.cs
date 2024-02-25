using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    private Collider2D collider;
    [SerializeField] private DialogueTrigger dialogue;
    private bool triggered;

    void Start()
    {
        dialogue = GetComponent<DialogueTrigger>();
        collider = GetComponent<Collider2D>();
        triggered = false;
    }


    void OnTriggerEnter2D(Collider2D thing)
    {

        if (thing.gameObject.CompareTag("Player") && !triggered)
        {
            triggered = true;
            dialogue.TriggerDialogue();
        }

    }
}
