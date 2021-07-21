using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer masterMixer;
    public AudioMixer sfxMixer;

    public void SetMasterVolume(float masterVolume)
    {
        masterMixer.SetFloat("volume", masterVolume);
    }

    public void SetSFXVolume(float sfxVolume)
    {
        sfxMixer.SetFloat("volume", sfxVolume);
    }
}
