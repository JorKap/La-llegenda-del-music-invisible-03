using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CartesTarotSaveSystem 
{
    public static void Save(CartesTarotSave cartaTarot, string fileName)
    {
        string jsonPath = Application.persistentDataPath + "/" + fileName + ".json";
        CartesTarotData data = new CartesTarotData(cartaTarot);
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(jsonPath, json);
        //Debug.Log("Save " + fileName + json);
    }

    public static CartesTarotData Load(string fileName)
    {
        string jsonPath = Application.persistentDataPath + "/" + fileName + ".json";
        if (File.Exists(jsonPath))
        {
            string jsonRead = File.ReadAllText(jsonPath);
            CartesTarotData data = JsonUtility.FromJson<CartesTarotData>(jsonRead);

            //Debug.Log("Load " + fileName + jsonRead);
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + jsonPath);
            return null;
        }
    }
}
