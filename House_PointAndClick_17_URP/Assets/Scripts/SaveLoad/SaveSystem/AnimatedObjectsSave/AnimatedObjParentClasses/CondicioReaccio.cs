using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondicioReaccio : Reaccio
{
    CondicionsSave condicionsSave;
    public bool estatCondicio;
    protected override void ExecutaReaccio()
    {
        condicionsSave.GetEstatCondicio(estatCondicio);

    }

}
