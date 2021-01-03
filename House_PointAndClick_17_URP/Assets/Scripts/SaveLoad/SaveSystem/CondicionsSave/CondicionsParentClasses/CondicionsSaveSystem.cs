using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CondicionsSaveSystem 
{
    public static void Save(CondicionsSave data, string fileName)
    {
        string jsonPath = Application.persistentDataPath + "/" + fileName + ".json";
        CondicionsData _data = new CondicionsData(data);
        string json = JsonUtility.ToJson(_data);
        File.WriteAllText(jsonPath, json);
       // Debug.Log("Save " + json);
    }

    public static CondicionsData Load(string fileName)
    {
        string jsonPath = Application.persistentDataPath + "/" + fileName + ".json";
        if (File.Exists(jsonPath))
        {
            string jsonRead = File.ReadAllText(jsonPath);
            CondicionsData data = JsonUtility.FromJson<CondicionsData>(jsonRead);

            //Debug.Log("Load " + jsonRead);
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + jsonPath);
            return null;
        }
    }
}
