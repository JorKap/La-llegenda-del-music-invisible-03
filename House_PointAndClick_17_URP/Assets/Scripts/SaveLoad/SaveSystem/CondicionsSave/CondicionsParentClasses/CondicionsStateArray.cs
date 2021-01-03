using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondicionsStateArray : MonoBehaviour
{
    public CondicionsSave[] condicionsSave;
    private void Start()
    {
        for (int i = 0; i < condicionsSave.Length; i++)
        {
           // Debug.Log("Nom condicions: " + condicionsSave[i].nomCondicio);
        }
    }
}
