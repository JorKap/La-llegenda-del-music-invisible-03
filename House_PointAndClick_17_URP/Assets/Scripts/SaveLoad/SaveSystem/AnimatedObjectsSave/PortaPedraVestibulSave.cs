using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaPedraVestibulSave : AnimatedObjSave
{
    string objName = "PortaPedraVestibul";
    

    protected override void Erase()
    {
        AnimatedObjSaveSystem.Save(this, objName);

    }
     

    private void OnEnable()
    {
        AnimatedObjData data =  AnimatedObjSaveSystem.Load(objName);
        //indexTimelineAsset = data.indexTimelineAsset;
        //if (timelineController != null && indexTimelineAsset == 1)
        //    timelineController.PlayFromTimelines(indexTimelineAsset);
        //col.enabled = enableCollider;
        setActive = data.setActive;
        gameObject.SetActive(setActive);

    }
    private void OnDisable()
    {
        AnimatedObjSaveSystem.Save(this, objName);
    }
}
