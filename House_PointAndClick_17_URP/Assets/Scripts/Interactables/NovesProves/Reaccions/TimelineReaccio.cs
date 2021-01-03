using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineReaccio : Reaccio
{
   
    public TimelineController timelineController;

    protected override void ExecutaReaccio()
    {
       timelineController.Play();
        
    }

}
