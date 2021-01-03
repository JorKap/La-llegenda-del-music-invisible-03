﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerManager : MonoBehaviour
{
    public AudioMixer mixer;
     public void SetVolumeMixer(float volume)
    {
        mixer.SetFloat("VolumeMixer", volume);
    }
}
