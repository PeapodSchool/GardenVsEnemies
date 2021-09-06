using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{

    public static string NEXT_LEVEL_KEY =
        "nextLevelToPlay";
    public static int LEVEL_TO_START = 1;

    public static string LAST_LEVEL_KEY =
        "lastPlayedLevel";
    public static int LEVEL_TO_PLAY = 1;

    public static string GAME_COMPLETE_KEY =
        "gameComplete";
    public static int GAME_INCOMPLETE = 0;
    public static int GAME_COMPLETE = 1;

    [SerializeField] Button[] levelButtons;
    [SerializeField] int totalSceneNumber = 25;

    // Start is called before the first frame update
    void Start()
    {
        EnableLevelLoadButtons();
    }

    private void EnableLevelLoadButtons()
    {
        if (levelButtons.Length == 0)
        {
            return;
        }
        int levelReached = PlayerPrefs.GetInt(
            NEXT_LEVEL_KEY, LEVEL_TO_START);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i > levelReached - 1)
            {
                levelButtons[i].interactable = false;
            }
        }
    }

    public void LoadLastPassedScene()
    {
        if (PlayerPrefs.GetInt(GAME_COMPLETE_KEY, GAME_INCOMPLETE) == 1)
        {
            SceneManager.LoadScene("SelectLevel");
            return;
        }
        int sceneToLoadIndex = PlayerPrefs.GetInt(LAST_LEVEL_KEY, LEVEL_TO_PLAY);
        SceneManager.LoadScene(sceneToLoadIndex);
    }

    public void LoadNextScene()
    {
        Time.timeScale = 1;

        if (PlayerPrefs.GetInt(GAME_COMPLETE_KEY, GAME_INCOMPLETE) == 1)
        {
            SceneManager.LoadScene("SelectLevel");
            return;
        }
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        int lastWrittenIndex = PlayerPrefs.GetInt(NEXT_LEVEL_KEY, LEVEL_TO_START);
        if (sceneIndex >= lastWrittenIndex)
        {
            PlayerPrefs.SetInt(NEXT_LEVEL_KEY, sceneIndex + 1);
        }
        SceneManager.LoadScene(sceneIndex + 1);
    }

    public void ClearProgress()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("LevelScelector");
    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public int GetTotalSceneNumber()
    {
        return totalSceneNumber;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevelSelectorScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SelectLevel");
    }

    public void LoadSettingsScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Settings");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void LoadSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
