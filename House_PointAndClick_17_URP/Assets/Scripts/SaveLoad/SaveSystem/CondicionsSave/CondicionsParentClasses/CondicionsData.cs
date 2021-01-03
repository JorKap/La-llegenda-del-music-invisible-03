using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CondicionsData 
{
    public string nomCondicio;
    public bool estatCondicio;

    public CondicionsData(CondicionsSave condicionsSave)
    {
        nomCondicio = condicionsSave.nomCondicio;
        estatCondicio = condicionsSave.estatCondicio;
    }
}
