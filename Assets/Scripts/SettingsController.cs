using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{

    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;
    [SerializeField] float defalutVolume = 0.6f;
    [SerializeField] int defaultDifficulty = 0;

    public const string VOLUME_KEY = "volumeKey";
    public const string DIFFICULTY_KEY = "defficultyKey";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;
    const int MIN_DIFFICULTY = 0;
    const int MAX_DIFFICULTY = 2;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = GetVolumeValue();
        difficultySlider.value = GetDifficultyValue();
    }

    public static float GetDifficultyValue()
    {
        return PlayerPrefs.GetInt(DIFFICULTY_KEY, MIN_DIFFICULTY);
    }

    public static float GetVolumeValue()
    {
        return PlayerPrefs.GetFloat(VOLUME_KEY, MIN_VOLUME);
    }

    public void SetDefaults()
    {
        volumeSlider.value = defalutVolume;
        difficultySlider.value = defaultDifficulty;
    }

    public void SaveAndExit()
    {
        PlayerPrefs.SetFloat(VOLUME_KEY, volumeSlider.value);
        PlayerPrefs.SetInt(DIFFICULTY_KEY, (int)difficultySlider.value);
        FindObjectOfType<Level>().LoadMainMenu();
    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.Log("No music player, it's an error!");
        }
    }
}
