using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EraseData 
{
    public int indexTimelineAsset;
    public bool enableCollider;
    public bool setActive;

    public EraseData(Erase erase)
    {
        indexTimelineAsset = erase.indexTimelineAsset;
        enableCollider = erase.enableCollider;
        setActive = erase.setActive;
    }
}
