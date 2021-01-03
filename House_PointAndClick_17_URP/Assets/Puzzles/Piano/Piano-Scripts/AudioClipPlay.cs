using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioClipPlay : MonoBehaviour
{
    public AudioClip audioClip;
    AudioSource source;
    Animator animator;
    Recording recording;

    private void Awake()
    {
        recording = FindObjectOfType<Recording>();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

   
    private void OnMouseDown()
    {

        animator.SetBool("stop", false);
        animator.SetBool("play", true);

        source = recording.source;
        source.clip = audioClip;
        source.Play();
        if(recording.timerActive)
            recording.audioClips.Add(audioClip);

    }

    private void OnMouseUp()
    {

        animator.SetBool("play", false);
        animator.SetBool("stop", true);
       

    }
}
