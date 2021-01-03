using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condicions : MonoBehaviour
{
    public Condicio[] condicions;
    public CondicionsStateArray condicionsState;
    private void Awake()
    {
        condicionsState = FindObjectOfType<CondicionsStateArray>();
    }

    public bool ComprovaCondicions()
    {
        for (int i = 0; i < condicions.Length; i++)
        {
            if (!RevisaTotesCondicions(condicions[i]))
            {
                return false;
            }
        }

        
        return true;
    }

    public bool RevisaTotesCondicions(Condicio condicio)
    {

        for (int i = 0; i < condicionsState.condicionsSave.Length; i++)
        {
            if(condicio.nomCondicio == condicionsState.condicionsSave[i].nomCondicio)
            {
                if (condicio.estatCondicio == condicionsState.condicionsSave[i].estatCondicio)
                {
                    return true;
                }
            }

        }
        return false;
    }
}
