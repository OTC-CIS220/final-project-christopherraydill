using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instances_Of_Scenes : MonoBehaviour {

    //instatiates an intstance to grab from other scripts
    public static Instances_Of_Scenes Instance { set; get; }

    //setup for a level
    private void Awake()
    {
        Instance = this;
        Load("P1");
    }

    //load scene
    public void Load(string sceneName)
    {
        if (!SceneManager.GetSceneByName(sceneName).isLoaded)
        {
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }
    }

    //unload scene
    public void Unload(string sceneName)
    {
        if (SceneManager.GetSceneByName(sceneName).isLoaded)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }
    }
}
