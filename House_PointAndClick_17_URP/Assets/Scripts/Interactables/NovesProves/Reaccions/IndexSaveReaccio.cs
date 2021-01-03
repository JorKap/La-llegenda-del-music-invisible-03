using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexSaveReaccio : Reaccio
{
    public int index;
    public PlayerManager player;
    protected override void ExecutaReaccio()
    {
        player.index = index;
    }
}
