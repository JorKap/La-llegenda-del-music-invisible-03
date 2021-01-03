using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PujarBaixarEscalesSave : AnimatedObjSave
{
    string objName = "PujarBaixarEscales";

    protected override void Erase()
    {
        AnimatedObjSaveSystem.Save(this, objName);

    }

    private void OnEnable()
    {
        AnimatedObjData data = AnimatedObjSaveSystem.Load(objName);
        indexTimelineAsset = data.indexTimelineAsset;
        if (timelineController != null && indexTimelineAsset > 0)
            timelineController.PlayFromTimelines(2);
        //col.enabled = enableCollider;
        //Debug.Log("PortesArmari");
    }
    private void OnDisable()
    {
        AnimatedObjSaveSystem.Save(this, objName);
    }
}

