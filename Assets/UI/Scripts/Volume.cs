using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{
    #region VARIABLES

    [Header("Mixer Groups")]
    [SerializeField] private AudioMixerGroup master;
    [SerializeField] private AudioMixerGroup ambienceMixerGroup;
    [SerializeField] private AudioMixerGroup effectsMixerGroup;

    [Header("Volume Sliders")]
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider ambienceSlider;
    [SerializeField] private Slider effectsSlider;

    #endregion

    void Start()
    {
        LoadVolume();
    }

    #region METHODS

    public void Update()
    {
        master.audioMixer.SetFloat("Master", Mathf.Log10(masterSlider.value) * 20);

        ambienceMixerGroup.audioMixer.SetFloat("Background", Mathf.Log10(ambienceSlider.value) * 20);

        effectsMixerGroup.audioMixer.SetFloat("Effects", Mathf.Log10(effectsSlider.value) * 20);
    }

    public void LoadVolume()
    {
        //At the start the value in the slider is set to the one that has been save or to 1f in case there's none
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume", 1f);
        ambienceSlider.value = PlayerPrefs.GetFloat("ambienceVolume", 1f);
        effectsSlider.value = PlayerPrefs.GetFloat("effectsVolume", 1f);
    }

    //BUTTONS FUNTIONS
    public void SaveVolume()
    {
        //The value given to the slider is saved
        PlayerPrefs.SetFloat("masterVolume", masterSlider.value);
        PlayerPrefs.SetFloat("ambienceVolume", ambienceSlider.value);
        PlayerPrefs.SetFloat("effectsVolume", effectsSlider.value);
    }

    public void ResetVolume()
    {
        PlayerPrefs.SetFloat("masterVolume", 1f);
        PlayerPrefs.SetFloat("ambienceVolume", 1f);
        PlayerPrefs.SetFloat("effectsVolume", 1f);

        LoadVolume();
    }

    public void MuteMaster()
    {
        masterSlider.value = 0f;
    }

    public void MuteMusic()
    {
        ambienceSlider.value = 0f;
    }

    public void MuteEffects()
    {
        effectsSlider.value = 0f;
    }

    #endregion

}