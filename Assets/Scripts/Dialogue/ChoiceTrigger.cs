using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.UI
{
    public class ChoiceTrigger : MonoBehaviour
    {

        public Choices choice;

        public void TriggerChoice()
        {
            //Debug.Log("triggerChoice()");
            
            FindObjectOfType<MetaGameController>().ToggleChoices(true);
            FindObjectOfType<ChoiceManager>().StartChoice(choice);
        }

    }
}
