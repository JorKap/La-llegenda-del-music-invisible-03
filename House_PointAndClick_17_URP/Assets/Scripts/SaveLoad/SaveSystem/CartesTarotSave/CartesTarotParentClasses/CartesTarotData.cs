using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CartesTarotData
{
   // public string nomCartaTarot;
    public bool cartaSetActive;

    public CartesTarotData(CartesTarotSave cartesTarotSave)
    {
        //nomCartaTarot = cartesTarotSave.nomCartaTarot;
        cartaSetActive = cartesTarotSave.cartaSetActive;
    }
}
