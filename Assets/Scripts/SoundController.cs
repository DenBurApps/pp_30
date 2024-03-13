using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource[] audioSources;
    [SerializeField] private GameObject enabledMark;
    [SerializeField] private GameObject disabledMark;

    public void DisableAllSound()
    {
        foreach (var sound in audioSources) { sound.mute = true; }
        enabledMark.SetActive(false);
        disabledMark.SetActive(true);

    }
    public void EnableAllSound()
    {
        foreach (var sound in audioSources) { sound.mute = false; }
        enabledMark.SetActive(true);
        disabledMark.SetActive(false);

    }
}
