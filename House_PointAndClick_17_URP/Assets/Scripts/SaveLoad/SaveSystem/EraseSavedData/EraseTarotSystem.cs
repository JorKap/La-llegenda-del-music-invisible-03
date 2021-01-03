using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EraseTarotSystem 
{
    public static void Save(EraseTarot cartaTarot, string fileName)
    {
        string jsonPath = Application.persistentDataPath + "/" + fileName + ".json";
        EraseTarotData data = new EraseTarotData(cartaTarot);
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(jsonPath, json);
        Debug.Log("Save " + fileName + json);
    }
}
