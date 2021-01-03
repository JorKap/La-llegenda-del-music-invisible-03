using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEnableReaccio : Reaccio
{
    public Collider col;
    public bool colEnable;
   
    protected override void ExecutaReaccio()
    {
        col.enabled = colEnable;
    }

    
}
