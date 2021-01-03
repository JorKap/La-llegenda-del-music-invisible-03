using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetQuizResult : CondicionsSave
{
    
    public string condicioName = "QuizCondicio";

    public void SaveQuizResult()
    {
        CondicionsSaveSystem.Save(this, condicioName);

    }
   
   
}
