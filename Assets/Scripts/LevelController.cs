using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] AudioClip winSound;
    [SerializeField] float winSoundVolume = 0.5f;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void AttackerSpawned() { numberOfAttackers++; }

    public void AttackerKilled() 
    { 
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelTimerFinished
            && FindObjectOfType<LivesDisplay>().GetLives() > 0)
        {
            HandleWinCounditions();
        }
    }

    private void HandleWinCounditions()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        int totalSceneNumber = FindObjectOfType<Level>().GetTotalSceneNumber();
        if (sceneIndex == totalSceneNumber)
        {
            PlayerPrefs.SetInt(Level.GAME_COMPLETE_KEY, Level.GAME_COMPLETE);
        }

        winLabel.SetActive(true);

        if (PlayerPrefs.GetInt(Level.GAME_COMPLETE_KEY, Level.GAME_INCOMPLETE) ==
            Level.GAME_INCOMPLETE)
        {
            PlayerPrefs.SetInt(Level.NEXT_LEVEL_KEY, sceneIndex + 1);
        }
        PlayerPrefs.SetInt(Level.LAST_LEVEL_KEY, sceneIndex + 1);
        AudioSource.PlayClipAtPoint(winSound, Camera.main.transform.position, winSoundVolume);
        Time.timeScale = 0;
    }

    public void HandleLoseCounditions()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        EnemySpawner[] spawners = FindObjectsOfType<EnemySpawner>();
        foreach(EnemySpawner spawner in spawners)
        {
            spawner.StopSpawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
