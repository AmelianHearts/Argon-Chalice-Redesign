using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.UI
{
    [System.Serializable]
    public class Choices
    {
        [TextArea(3, 10)]
        public string[] choices;

        [TextArea(3, 10)]
        public string question;
        public bool[] isAvailable;

        public DialogueTrigger[] results;
    }
}
