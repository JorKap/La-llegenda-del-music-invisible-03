using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartesTarotSaveReaccio : Reaccio
{
    public Item item;
    public GameObject carta;
    public CartesTarotSave tarotSave;
    public bool cartaSetActive;
    protected override void ExecutaReaccio()
    {
        tarotSave.SaveEstatCartaTarotAgafada(cartaSetActive);
        carta.SetActive(cartaSetActive);
        Inventory.instance.Add(item);
    }

    
}
