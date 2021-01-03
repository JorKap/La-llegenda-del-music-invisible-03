using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public abstract class AnimatedObjSave : MonoBehaviour
{
    public TimelineController timelineController;
    public int indexTimelineAsset;
    public Collider col;
    public bool enableCollider;
    public bool setActive;

    private void Awake()
    {
        timelineController = GetComponent<TimelineController>();
    }
    public void EraseData()
    {
        Erase();
    }

    public void SaveIndexTimelineAsset(int index)
    {
        indexTimelineAsset = index;
    }
    public void SaveEnableCollider(bool enable)
    {
        enableCollider = enable;
    }
    public void SaveSetActive(bool active)
    {
        setActive = active;
    }
   
    protected abstract void Erase();
}
