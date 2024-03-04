using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.UI
{
    public class TestStart : MonoBehaviour
    {
        [SerializeField] public DialogueTrigger start;

        // Start is called before the first frame update
        void Update()
        {
            // start = GetComponent<DialogueTrigger>();
            if (Input.GetMouseButtonDown(0))
            {
                start.TriggerDialogue();
                this.enabled = false;
            }
                
        }

    }
}
