using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        MusicPlayer[] musicPlayers = FindObjectsOfType<MusicPlayer>();
        if (musicPlayers.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
            audioSource = GetComponent<AudioSource>();
            audioSource.volume = SettingsController.GetVolumeValue();
        }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
