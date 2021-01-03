using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Recording : MonoBehaviour
{
   // public static Recording instance;
    
   
    public List<AudioClip> audioClips = new List<AudioClip>();
    public List<float> notesLength = new List<float>();

    public Text infoResults;
 //   public Text fiDelJoc;

    public OriginalMelodie originalMelodie;

    public Toggle toggleRecButton;
    public Toggle togglePlayButton;

    public CrossFadeScene fadeScene;
    public GameObject butonTornarAlJoc;
    public GameObject panelTextFinal;

    [HideInInspector]
    public AudioSource source;

   // public Text startBtnText;

    public bool timerActive = false;
    private float lastClickTime;
    private int t = 0;

    private bool benTocat;
    private bool nombreNotesCorrecte;

    private void Awake()
    {
        //if(instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(this);
        //}
        //else
        //{
        //    Destroy(this);
        //    Debug.Log("Destroy");
        //}

        source = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (timerActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                float timeSinceLastClick = Time.time - lastClickTime;

                lastClickTime = Time.time;
                notesLength.Add(timeSinceLastClick );
            }

        }
    }

   
    public void SongsCompare()
    {

        if (audioClips.Count == originalMelodie.audioClip.Count)
        {
            nombreNotesCorrecte = true;
            for (int i = 0; i < audioClips.Count; i++)
            {
                if (audioClips[i].name == originalMelodie.audioClip[i].audioClip.name)
                {
                    benTocat = true;
                }
                else
                {
                    benTocat = false;

                }

            }

        }
        else
        {
            nombreNotesCorrecte = false;
        }
        StartCoroutine(TextResultatComparativa());

    }

    private IEnumerator TextResultatComparativa()
    {
        if (nombreNotesCorrecte)
        {
            if (benTocat)
            {
               // fiDelJoc.text = "Gràcies amic! Per fi he aconseguit la llibertat";
                butonTornarAlJoc.SetActive(false);
                panelTextFinal.SetActive(true);
                Debug.Log("Ben tocat");
                yield return new WaitForSeconds(7);
                //fiDelJoc.text = "";
                fadeScene.LoadSelectedScene("Menu");
            }
            else
            {
                infoResults.text = "Error, t'has equivocat de notes, torna-ho a provar";
                yield return new WaitForSeconds(5);
                infoResults.text = "";

            }
        }
        else
        {
            infoResults.text = "Error, no has tocat el nombre de notes de què consta la melodia, torna-ho a provar";
            yield return new WaitForSeconds(5);
            infoResults.text = "";
        }
    }
    bool reset;
    public void SongReset()
    {
        reset = true;
        infoResults.text = "";
        audioClips.Clear();
        notesLength.Clear();
        StopAllCoroutines();
    }

    public void Rec()
    {
        timerActive = true;
    }

    public void RecButton(bool toggle)
    {
        if (toggle == true)
        {
            togglePlayButton.isOn = false;
            SongReset();
            source.volume = 1;
            Rec();
        }
        else
        {
            timerActive = false;
            
        }
    }

    public void PlayButton(bool toggle)
    {
        Debug.Log("Toggle " + toggle);

        if (toggle == true)
        {
            source.volume = 1;
            PlayRecording();
            toggleRecButton.isOn = false;


        }
        else
        {
            source.volume = 0;

        }

    }

    public void PlayRecording()
    {
        reset = false;
        timerActive = false;
        SongsCompare();

        if (audioClips.Count > 0)
        {
            StartCoroutine(PlayNotes());
            StopCoroutine(PlayNotes());

        }
    }

    
   IEnumerator PlayNotes()
   {
        notesLength[0] = 0;
        while(t < audioClips.Count )
        {

            yield return new WaitForSeconds(notesLength[t]);
            source.clip = audioClips[t];
            source.Play();
            t++;
           
        }
        
        t = 0;
    }

    //IEnumerator MenuPrincipal()
    //{
    //    fadeScene.
    //}

}



