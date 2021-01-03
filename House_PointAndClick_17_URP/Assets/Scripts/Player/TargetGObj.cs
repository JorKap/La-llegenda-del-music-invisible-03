using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGObj : MonoBehaviour
{
    
    public Collider col;
   

    private void Awake()
    {
        col = GetComponent<Collider>();
       
    }
}
