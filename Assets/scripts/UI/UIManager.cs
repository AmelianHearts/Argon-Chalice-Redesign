using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header ("Game Over")]
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;

    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;

    [Header("Notebook")]
    [SerializeField] private GameObject notebookScreen;
    public int currentDisplay { get; private set; }

    [Header("Dialogue")]
    [SerializeField] private GameObject dialogueScreen;


    private void Awake()
    {
        gameOverScreen.SetActive(false);
        pauseScreen.SetActive(false);
        notebookScreen.SetActive(false);
        dialogueScreen.SetActive(false);
        currentDisplay = 0;
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //If pause screen already active unpause and viceversa
            PauseGame(!pauseScreen.activeInHierarchy);
        }

        if (Input.GetKeyDown(KeyCode.E) && !pauseScreen.activeInHierarchy)
        {
            OpenNotebook(!notebookScreen.activeInHierarchy);
        }
    }

    #region Game Over
    //Activate game over screen
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        SoundManager.instance.PlaySound(gameOverSound);
    }

    //Restart level
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Main Menu
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //Quit game/exit play mode if in Editor
    public void Quit()
    {
        Application.Quit(); //Quits the game (only works in build)

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //Exits play mode (will only be executed in the editor)
#endif
    }
    #endregion

    #region Pause
    public void PauseGame(bool status)
    {
        //If status == true pause | if status == false unpause
        pauseScreen.SetActive(status);

        //When pause status is true change timescale to 0 (time stops)
        //when it's false change it back to 1 (time goes by normally)
        if (status)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
    public void SoundVolume()
    {
        SoundManager.instance.ChangeSoundVolume(0.2f);
    }
    public void MusicVolume()
    {
        SoundManager.instance.ChangeMusicVolume(0.2f);
    }
    #endregion

    #region Notebook
    public void OpenNotebook(bool status)
    {
        notebookScreen.SetActive(status);
        CollectableList.Instance.DisplayItem(currentDisplay);

        if (status)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;

       //CollectableList.Instance.HideItem();
    }

    public void Next()
    {
        if (currentDisplay < CollectableList.Instance.Collectables.Length-1)
        {
            currentDisplay++;
            CollectableList.Instance.DisplayItem(currentDisplay);
        }
            
    }

    public void Previous()
    {
        if (currentDisplay > 0)
        {
            currentDisplay--;
            CollectableList.Instance.DisplayItem(currentDisplay);
        }
            
    }

    #endregion

    #region Dialogue
    public void Dialogue(bool status)
    {
        //If status == true pause | if status == false unpause
        dialogueScreen.SetActive(status);

        //When pause status is true change timescale to 0 (time stops)
        //when it's false change it back to 1 (time goes by normally)
        if (status)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
    #endregion
}