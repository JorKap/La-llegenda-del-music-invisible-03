using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexTimelineAssetReaccio : Reaccio
{
    public TimelineController timeline;
    public int indexTimelineAsset;
    protected override void ExecutaReaccio()
    {
        timeline.PlayFromTimelines(indexTimelineAsset);
    }
}
