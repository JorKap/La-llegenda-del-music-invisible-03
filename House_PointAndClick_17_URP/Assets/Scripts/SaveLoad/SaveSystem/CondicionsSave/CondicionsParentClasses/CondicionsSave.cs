using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondicionsSave : MonoBehaviour
{
    public bool estatCondicio;
    public string nomCondicio;


    public void EraseData()
    {
        CondicionsSaveSystem.Save(this, nomCondicio);
    }

    public void GetEstatCondicio(bool estat)
    {
        estatCondicio = estat;
    }
    public void SaveLoad()
    {
        CondicionsSaveSystem.Save(this, nomCondicio);
        CondicionsData data = CondicionsSaveSystem.Load(nomCondicio);
        estatCondicio = data.estatCondicio;
    }
    private void OnEnable()
    {
        CondicionsData data = CondicionsSaveSystem.Load(nomCondicio);

        estatCondicio = data.estatCondicio;
    }

    private void OnDisable()
    {
        CondicionsSaveSystem.Save(this, nomCondicio);
    }

}
