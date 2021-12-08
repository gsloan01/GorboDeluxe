using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance { get; private set; }
    List<AudioSource> soundEffects = new List<AudioSource>();
    public AudioMixerGroup sfx;

    private void Awake()
    {
        Instance = this;
    }

    public void Clear(bool delete)
    {
        if(soundEffects.Count > 0)
        {
            foreach (var v in soundEffects)
            {
                if(v.gameObject == null)
                {
                    soundEffects.Remove(v);
                }
                else
                if (v.gameObject.activeSelf)
                {
                    if (delete) Destroy(v.gameObject);
                    else
                    {
                        v.Stop();
                        v.gameObject.SetActive(false);
                    }
                }
            }
        }

    }
    public void PlaySFX(AudioClip soundClip, Transform locator, bool parent = true)
    {
        GameObject newSFX = null;

        if (parent)
        {
            newSFX = Instantiate(new GameObject(soundClip.name + " SFX"), locator);
        }
        else
        {
            newSFX = Instantiate(new GameObject(soundClip.name + " SFX"), locator.position, locator.rotation);
        }
        AudioSource source = newSFX.AddComponent<AudioSource>();
        source.clip = soundClip;
        source.outputAudioMixerGroup = sfx;
        source.Play();
        soundEffects.Add(source);
        Destroy(newSFX, soundClip.length);
    }
}
