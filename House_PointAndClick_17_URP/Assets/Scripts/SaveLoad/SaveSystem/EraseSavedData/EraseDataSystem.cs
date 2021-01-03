using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EraseDataSystem 
{
    public static void Save(Erase data, string fileName)
    {
        string jsonPath = Application.persistentDataPath + "/" + fileName + ".json";
        EraseData portaEntrada = new EraseData(data);
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(jsonPath, json);
        Debug.Log("Save " + json);
    }
}
