using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.UI
{
    [System.Serializable]
    public class Dialogue
    {

        public string[] names;
        public int[] speakers;

        [TextArea(3, 10)]
        public string[] sentences;

        public bool choiceAtEnd;
        public ChoiceTrigger paths;

        public bool changeScene;

    }
}
