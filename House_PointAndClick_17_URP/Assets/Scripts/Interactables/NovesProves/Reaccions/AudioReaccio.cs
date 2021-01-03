using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioReaccio : Reaccio
{
    public AudioSource source;
    protected override void ExecutaReaccio()
    {
        source.Play();
    }

    
}
