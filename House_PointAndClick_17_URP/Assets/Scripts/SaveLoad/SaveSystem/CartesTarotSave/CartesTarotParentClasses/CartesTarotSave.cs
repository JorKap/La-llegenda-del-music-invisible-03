using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CartesTarotSave : MonoBehaviour
{
    public GameObject carta;
    public Item item;
    public GameObject buttonShowCarta;
    public bool cartaSetActive;
   

    public void EraseData()
    {
        Erase();
    }

    

    public virtual void SaveEstatCartaTarotAgafada(bool enable)
    {
        cartaSetActive = enable;
    }
    protected abstract void Erase();
}
