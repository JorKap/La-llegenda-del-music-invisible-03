using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstatPuzzlesReaccio : Reaccio
{
    public GetEstatCondicio estatCondicio;

    protected override void ExecutaReaccio()
    {
        estatCondicio.SaveEstatCondicio();
    }


}
