using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AnimatedObjSaveSystem 
{
    public static void Save(AnimatedObjSave data, string fileName)
    {
        string jsonPath = Application.persistentDataPath + "/" + fileName + ".json";
        AnimatedObjData portaEntrada = new AnimatedObjData(data);
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(jsonPath, json);
       // Debug.Log("Save " + json);
    }

    public static AnimatedObjData Load(string fileName)
    {
        string jsonPath = Application.persistentDataPath + "/" + fileName + ".json";
        if (File.Exists(jsonPath))
        {
            string jsonRead = File.ReadAllText(jsonPath);
            AnimatedObjData data = JsonUtility.FromJson<AnimatedObjData>(jsonRead);

           // Debug.Log("Load " + jsonRead);
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + jsonPath);
            return null;
        }
    }
}
