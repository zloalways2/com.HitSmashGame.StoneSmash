using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundSetter : MonoBehaviour
{
    [SerializeField] private Slider soundSlider;
    [SerializeField] private Slider musicSlider;

    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioSource musicSource;

    private void Start()
    {
        float soundValue = PlayerPrefs.GetFloat("Sound", 1);
        soundSlider.value = soundValue;
        soundSource.volume = soundValue;

        float musicValue = PlayerPrefs.GetFloat("Music", 1);
        musicSlider.value = musicValue;
        musicSource.volume = musicValue;
    }

    public void SetSoundVolume(Single value)
    {
        soundSlider.value = value;
        soundSource.volume = value;

        PlayerPrefs.SetFloat("Sound", value);
    }

    public void SetMusicVolume(Single value)
    {
        musicSlider.value = value;
        musicSource.volume = value;

        PlayerPrefs.SetFloat("Music", value);
    }
}
