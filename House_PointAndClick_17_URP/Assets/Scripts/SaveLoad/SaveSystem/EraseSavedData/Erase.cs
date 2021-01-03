using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Erase : MonoBehaviour
{
    //public TotesCondicionsScriptable state;
    public int indexTimelineAsset = 0;
    public bool enableCollider = true;
    public bool setActive = true;
    public void EraseData()
    {
        EraseDataSystem.Save(this, "PortaEntrada");
        EraseDataSystem.Save(this, "PortaEscala");
        EraseDataSystem.Save(this, "PortaPedraVestibul");
        EraseDataSystem.Save(this, "PortaSalaPiano");
        EraseDataSystem.Save(this, "PortesArmari");

    }
}
