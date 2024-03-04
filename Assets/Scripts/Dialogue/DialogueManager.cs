using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class DialogueManager : MonoBehaviour
    {

        public Text nameText0;
        public Text nameText1;
        public Text dialogueText;

        public Image[] nameBoxes;

        [SerializeField] public MetaGameController controller;

        //public Animator animator;

        bool choiceAtEnd;
        bool changeScene;

        private ChoiceTrigger choice;

        private Queue<string> sentences = new Queue<string>();
        private Queue<string> names = new Queue<string>();
        private Queue<int> speakers = new Queue<int>();

        /*// Use this for initialization
        void Start()
        {
            sentences = new Queue<string>();
            names = new Queue<string>();
            speakers = new Queue<int>();

        }
        */
        public void StartDialogue(Dialogue dialogue)
        {
            //animator.SetBool("IsOpen", true);

            if (sentences != null)
            {
                sentences.Clear();
                names.Clear();
                speakers.Clear();
            }
            

            choiceAtEnd = dialogue.choiceAtEnd;
            changeScene = dialogue.changeScene;

            if (choiceAtEnd)
            {
                choice = dialogue.paths;
            }

            //Time.timeScale = 0;

            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }

            foreach (string name in dialogue.names)
            {
                names.Enqueue(name);
            }

            foreach (int speaker in dialogue.speakers)
            {
                speakers.Enqueue(speaker);
            }
            DisplayNextSentence();
        }

        public void DisplayNextSentence()
        {
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

            string sentence = sentences.Dequeue();
            string name = names.Dequeue();
            int speaker = speakers.Dequeue();


            foreach (var i in nameBoxes) i.color = new Color32(72, 99, 86, 100);
            if (speaker != 2)
            {
                nameBoxes[speaker].color = new Color32(72, 99, 86, 200);

                if (speaker == 0)
                {
                    nameText0.text = name;
                }

                else if (speaker == 1)
                {
                    nameText1.text = name;
                }
            }
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }

        IEnumerator TypeSentence(string sentence)
        {
            dialogueText.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return null;
            }
        }


        void EndDialogue()
        {
            //Time.timeScale = 1;
            //animator.SetBool("IsOpen", false);

            if (choiceAtEnd)
            {
                controller.ToggleChoices(true);
                choice.TriggerChoice();

            }

            else if (changeScene)
            {
                controller.ChangeScene(true);
            }
            
             nameText0.text = " ";
             nameText1.text = " ";
             controller.ToggleDialogue(false);
            
        }

    }
}