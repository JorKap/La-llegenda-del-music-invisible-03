using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsPersistentData : MonoBehaviour
{
    public static void SaveData(PlayerManager player)
    {
       
        PlayerPrefs.SetString("name", player.transform.parent.parent.name);
        PlayerPrefs.SetInt("index", player.index);
        
    }

    public static PlayerPrefsData LoadData()
    {
      
        string parentName = PlayerPrefs.GetString("name", "StartPosition");
        int newIndex = PlayerPrefs.GetInt("index", 0);

        PlayerPrefsData prefsData = new PlayerPrefsData()
        {

            LocationName = parentName,
            index = newIndex
        };

        return prefsData;
    }

    
}
