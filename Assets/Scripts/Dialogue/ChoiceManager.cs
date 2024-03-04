using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer.UI
{
    public class ChoiceManager : MonoBehaviour
    {
        [SerializeField] public Text[] options;

        [SerializeField] public Button[] choices;

        [SerializeField] public Text question;

        [SerializeField] public GameObject[] buttons;

        public bool[] available;

        public void StartChoice(Choices choice)
        {
            available = choice.isAvailable;
            //Debug.Log(available);
            question.text = choice.question;

            for (int i = 0; i < options.Length;  i++)
            {
                if (i < choice.isAvailable.Length)
                {
                    if (available[i])
                    {
                        //Debug.Log(i.ToString());
                        choices[i].enabled = true;
                        options[i].enabled = true;
                        choices[i].interactable = true;
                        options[i].text = choice.choices[i];

                        int x = new int();
                        x = i;
                        choices[x].onClick.AddListener(delegate { choice.results[x].TriggerDialogue(); });
                    }
                    else if (!available[i])
                    {
                        choices[i].enabled = true;
                        options[i].enabled = true;
                        choices[i].interactable = false;
                        options[i].text = "???";
                    }
                    else
                    {
                        choices[i].enabled = false;
                        options[i].enabled = false;

                    }
                }
                else
                {
                    buttons[i].SetActive(false);
                    
                }
            }
        }
     
    }
}