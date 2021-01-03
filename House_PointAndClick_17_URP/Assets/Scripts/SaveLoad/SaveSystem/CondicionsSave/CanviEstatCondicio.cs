using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanviEstatCondicio : CondicionsSave
{
    public string condicioName = "";

    public void SaveQuizResult()
    {
        CondicionsSaveSystem.Save(this, condicioName);

    }

   
}
