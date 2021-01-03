using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstatCondicionsReaccio : Reaccio
{
    public CondicionsSave condicio;
    public bool estatCondicio;
    protected override void ExecutaReaccio()
    {
        condicio.estatCondicio = estatCondicio;
        condicio.SaveLoad();
    }

   
}
