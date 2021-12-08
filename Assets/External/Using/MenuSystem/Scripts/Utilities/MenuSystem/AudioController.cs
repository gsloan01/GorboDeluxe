using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public AudioController Instance { get { return Instance; } }
    AudioController instance;

    public AudioMixer audioMixer;

    void Start()
    {
        instance = this;

        float masterVolume = PlayerPrefs.GetFloat("MasterVolume", 0);
        audioMixer?.SetFloat("MasterVolume", masterVolume);

        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0);
        audioMixer?.SetFloat("MusicVolume", musicVolume);

        float sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 0);
        audioMixer?.SetFloat("SFXVolume", sfxVolume);
    }

    public void SetMasterVolume(float level)
    {
        audioMixer?.SetFloat("MasterVolume", level);
        PlayerPrefs.SetFloat("MasterVolume", level);
    }

    public void SetMusicVolume(float level)
    {
        audioMixer?.SetFloat("MusicVolume", level);
        PlayerPrefs.SetFloat("MusicVolume", level);
    }

    public void SetSFXVolume(float level)
    {
        audioMixer?.SetFloat("SFXVolume", level);
        PlayerPrefs.SetFloat("SFXVolume", level);
    }
}
