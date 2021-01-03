using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaSacerdotessaSave : CartesTarotSave
{
    string fileName = "LaSacerdotessa";


    private void Start()
    {
        if (!cartaSetActive)
        {
            Inventory.instance.Add(item);
            buttonShowCarta.SetActive(true);

        }


    }
    protected override void Erase()
    {
        CartesTarotSaveSystem.Save(this, fileName);
    }


    private void OnEnable()
    {
        CartesTarotData data = CartesTarotSaveSystem.Load(fileName);
        cartaSetActive = data.cartaSetActive;
        carta.gameObject.SetActive(cartaSetActive);

    }


    private void OnDisable()
    {
        CartesTarotSaveSystem.Save(this, fileName);
    }
}
