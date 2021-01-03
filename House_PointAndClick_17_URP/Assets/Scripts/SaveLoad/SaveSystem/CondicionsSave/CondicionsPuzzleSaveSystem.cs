using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CondicionsPuzzleSaveSystem 
{
    public static void Save(CondicionsSave data, string fileName)
    {
        string jsonPath = Application.persistentDataPath + "/" + fileName + ".json";
        CondicionsData _data = new CondicionsData(data);
        string json = JsonUtility.ToJson(_data);
        File.WriteAllText(jsonPath, json);
        Debug.Log("Save " + json);
    }


}
