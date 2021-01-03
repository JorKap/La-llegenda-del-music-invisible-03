using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaEntradaSave : AnimatedObjSave
{
    string objName = "PortaEntrada";

    protected override void Erase()
    {
        AnimatedObjSaveSystem.Save(this, objName);

    }

    private void OnEnable()
    {
        AnimatedObjData data = AnimatedObjSaveSystem.Load(objName);
        indexTimelineAsset = data.indexTimelineAsset;
        if (timelineController != null && indexTimelineAsset == 1)
            timelineController.PlayFromTimelines(indexTimelineAsset);
        col.enabled = enableCollider;
    }
    private void OnDisable()
    {
        AnimatedObjSaveSystem.Save(this, objName);
    }
}
