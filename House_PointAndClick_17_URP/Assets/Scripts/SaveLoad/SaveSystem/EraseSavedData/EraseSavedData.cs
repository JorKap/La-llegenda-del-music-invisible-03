using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EraseSavedData : MonoBehaviour
{

    public PlayerManager player;
    
    public AnimatedObjSave[] animatedObjSaves;
    public CartesTarotSave[] cartesTarot;
    public Reaccio[] esborrarJsonInfo;
    public EstatCondicionsReaccio[] estatCondicionsReaccio;


    public void EsborrarData()
    {
        
        foreach (Reaccio reaccio in esborrarJsonInfo)
        {
            reaccio.Reacciona();
        }
        foreach (AnimatedObjSave objSave in animatedObjSaves)
        {
            objSave.EraseData();
        }
        foreach (CartesTarotSave cartes in cartesTarot)
        {
            cartes.EraseData();
        }

        foreach (EstatCondicionsReaccio estatCondicions in estatCondicionsReaccio)
        {
            estatCondicions.Reacciona();
        }
        player.ErasePrefsData();
    }
    
}
