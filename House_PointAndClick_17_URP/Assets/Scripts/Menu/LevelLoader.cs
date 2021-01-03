using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;
    private TotesCondicionsScriptable condicionsScriptable;
    //delegate void Erase();
    //Erase erase;
    // private SaveLoad loadSavedData;

    private void Start()
    {
        //loadSavedData = FindObjectOfType<SaveLoad>();
        
    }
    
    public void DeleteGameProgressData()
    {
       // condicionsScriptable = Resources.Load<TotesCondicionsScriptable>("TotesCondicions");

        //foreach (Condicio condicio in condicionsScriptable.condicions)
        //{
        //    condicio.estatCondicio = false;
        //}


        PlayerPrefs.DeleteAll();


    }
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
       // loadSavedData.LoadGame();
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            Debug.Log(progress);
            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;

        }

    }
}
