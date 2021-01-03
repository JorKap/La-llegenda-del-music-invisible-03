using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class EraseConditionsData
{
    public string nomCondicio;
    public bool estatCondicio;

    public EraseConditionsData(EraseConditions condicionsErase)
    {
        estatCondicio = condicionsErase.estatCondicio;
    }
}
