using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EraseConditionsSaveSystem
{ 
    public static void Save(EraseConditions data, string fileName)
    {
        string jsonPath = Application.persistentDataPath + "/" + fileName + ".json";
        EraseConditionsData _data = new EraseConditionsData(data);
        string json = JsonUtility.ToJson(_data);
        File.WriteAllText(jsonPath, json);
        // Debug.Log("Save " + json);
    }
}
