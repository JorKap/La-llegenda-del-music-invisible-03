using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraseConditions : MonoBehaviour
{
    public bool estatCondicio;

    public void EraseConditionsData()
    {
        EraseConditionsSaveSystem.Save(this, "QuizResoltCondicio");
        EraseConditionsSaveSystem.Save(this, "CodiCorrecteCondicio");
        EraseConditionsSaveSystem.Save(this, "PuzzleChopinResoltCondicio");
        EraseConditionsSaveSystem.Save(this, "PuzzleColorsResoltCondicio");
        EraseConditionsSaveSystem.Save(this, "PianoResoltCondicio");
        EraseConditionsSaveSystem.Save(this, "ElDiableAgafatCondicio");
        EraseConditionsSaveSystem.Save(this, "LaSacerdotessaAgafadaCondicio");
        EraseConditionsSaveSystem.Save(this, "LaLlunaAgafadaCondicio");
        EraseConditionsSaveSystem.Save(this, "LaTempransaAgafadaCondicio");
        
    }
}
