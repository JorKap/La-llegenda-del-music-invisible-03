using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedObjSaveReaccio : Reaccio
{
    public AnimatedObjSave animatedObjSave;
    public int index;
    public bool enableCollider;
    public bool setActive;
    protected override void ExecutaReaccio()
    {
        animatedObjSave.SaveIndexTimelineAsset(index);
        animatedObjSave.SaveEnableCollider(enableCollider);
        animatedObjSave.SaveSetActive(setActive);
    }

   
}
