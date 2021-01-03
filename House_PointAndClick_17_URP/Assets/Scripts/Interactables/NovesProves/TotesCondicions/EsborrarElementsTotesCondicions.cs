using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsborrarElementsTotesCondicions : MonoBehaviour
{
    private TotesCondicionsScriptable condicionsScriptable;

    private void Awake()
    {
        condicionsScriptable = Resources.Load<TotesCondicionsScriptable>("TotesCondicions");
        
    }
   
    public void EraseElement()
    {
        //condicionsScriptable.condicions.RemoveAt();
    }
}
