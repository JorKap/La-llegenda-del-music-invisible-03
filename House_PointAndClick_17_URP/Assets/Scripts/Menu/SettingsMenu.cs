using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mixer;
    //public void SetVolumeMixer(float volume)
    //{
    //    mixer.SetFloat("VolumeMaster", volume);
    //}

    public void SetVolumeMusic(float volume)
    {
        mixer.SetFloat("VolumeMusic", volume);
    }

    public void SetVolumeSounds(float volume)
    {
        mixer.SetFloat("VolumeSounds", volume);
    }
}
