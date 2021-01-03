using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AnimatedObjData
{
    public int indexTimelineAsset;
    public bool enableCollider;
    public bool setActive;

    public AnimatedObjData(AnimatedObjSave animatedObj)
    {
        indexTimelineAsset = animatedObj.indexTimelineAsset;
        enableCollider = animatedObj.enableCollider;
        setActive = animatedObj.setActive;
    }
}
