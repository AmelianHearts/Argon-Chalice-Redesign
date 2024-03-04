using Platformer.Mechanics;
using Platformer.UI;
using UnityEngine;

namespace Platformer.UI
{
    /// <summary>
    /// The MetaGameController is responsible for switching control between the high level
    /// contexts of the application, eg the Main Menu and Gameplay systems.
    /// </summary>
    public class MetaGameController : MonoBehaviour
    {
        /// <summary>
        /// The main UI object which used for the menu.
        /// </summary>
        public MainUIController mainMenu;
        public MainUIController dialogueUI;
        public MainUIController choiceUI;

        /// <summary>
        /// A list of canvas objects which are used during gameplay (when the main ui is turned off)
        /// </summary>
        public Canvas[] gamePlayCanvasii;

        /// <summary>
        /// The game controller.
        /// </summary>
        public GameController gameController;

        bool showMainCanvas = false;
        bool showDialogue = false;
        bool showChoices = false;
        bool changeScene = false;

        void OnEnable()
        {
            _ToggleMainMenu(showMainCanvas);
            _ToggleDialogue(showDialogue);
            _ToggleChoices(showChoices);
        }

        /// <summary>
        /// Turn the main menu on or off.
        /// </summary>
        /// <param name="show"></param>
        public void ToggleMainMenu(bool show)
        {
            if (this.showMainCanvas != show)
            {
                _ToggleMainMenu(show);
            }
        }

        public void ToggleDialogue(bool show)
        {
            if (this.showDialogue != show)
            {
                _ToggleDialogue(show);
            }
        }

        public void ToggleChoices(bool show)
        {
            if (this.showChoices != show)
            {
                _ToggleChoices(show);
            }
        }

        public void ChangeScene(bool show)
        {
            changeScene = show;
        }


        void _ToggleMainMenu(bool show)
        {
            if (show)
            {
                Time.timeScale = 0;
                mainMenu.gameObject.SetActive(true);
                foreach (var i in gamePlayCanvasii) i.gameObject.SetActive(false);
            }
            else
            {
                Time.timeScale = 1;
                mainMenu.gameObject.SetActive(false);
                foreach (var i in gamePlayCanvasii) i.gameObject.SetActive(true);
            }
            this.showMainCanvas = show;
        }

        void _ToggleDialogue(bool show)
        {
            if (show)
            {
                Time.timeScale = 0;
                dialogueUI.gameObject.SetActive(true);
                foreach (var i in gamePlayCanvasii) i.gameObject.SetActive(false);
            }
            else
            {
                Time.timeScale = 1;
                dialogueUI.gameObject.SetActive(false);
                foreach (var i in gamePlayCanvasii) i.gameObject.SetActive(true);
            }
            this.showDialogue = show;
        }

        void _ToggleChoices(bool show)
        {
            if (show)
            {
                Time.timeScale = 0;
                choiceUI.gameObject.SetActive(true);
                foreach (var i in gamePlayCanvasii) i.gameObject.SetActive(false);
            }
            else
            {
                Time.timeScale = 1;
                choiceUI.gameObject.SetActive(false);
                foreach (var i in gamePlayCanvasii) i.gameObject.SetActive(true);
            }
            this.showChoices = show;
        }

        void Update()
        {
            if (Input.GetButtonDown("Menu"))
            {
                ToggleMainMenu(show: !showMainCanvas);
            }

            else if(showDialogue)
            {
                ToggleDialogue(true);
            }
            
            if (changeScene)
            {
                FindObjectOfType<LevelLoader>().LoadNextLevel();
            }
            
        }

    }
}
