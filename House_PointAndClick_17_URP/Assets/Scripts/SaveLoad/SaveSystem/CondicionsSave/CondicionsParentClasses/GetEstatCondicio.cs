using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEstatCondicio : CondicionsSave
{
    public bool estat;
    private void Start()
    {
        estatCondicio = estat;
    }

    public void SaveEstatCondicio()
    {
        CondicionsSaveSystem.Save(this, nomCondicio);

    }


}
