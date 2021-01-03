using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizCondicioSave : CondicionsSave
{
    public string condicioName = "QuizCondicio";

    private void Start()
    {
       
        Debug.Log("EstatCondicio " + estatCondicio);
    }
   
    //protected override void Erase()
    //{
    //    CondicionsSaveSystem.Save(this, condicioName);
    //}

    private void OnEnable()
    {
        CondicionsData data = CondicionsSaveSystem.Load(condicioName);

        estatCondicio = data.estatCondicio;
    }

    private void OnDisable()
    {
        CondicionsSaveSystem.Save(this, condicioName);
    }
}
