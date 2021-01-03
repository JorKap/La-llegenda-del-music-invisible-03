using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraseTarot : MonoBehaviour
{
    public bool cartaSetActive = true;

    public void EraseTarotData()
    {
        EraseTarotSystem.Save(this, "ElDiable");
        EraseTarotSystem.Save(this, "LaSacerdotessa");
        EraseTarotSystem.Save(this, "LaLluna");
        EraseTarotSystem.Save(this, "LaTempransa");
    }
}
