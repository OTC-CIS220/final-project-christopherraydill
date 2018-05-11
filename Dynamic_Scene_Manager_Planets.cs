using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dynamic_Scene_Manager_Planets : MonoBehaviour {

    //allows for targeting of scenes to load and unload
    public string loadName;
    public string[] unloadName;

    private void OnTriggerEnter(Collider col)
    {
        //checks if loadName is blank
        if (loadName != "")
        {
            //gets the Instances_Of_Scenes load function and uses it here
            Instances_Of_Scenes.Instance.Load(loadName);
        }

        //checks if unloadName is blank
        if (unloadName[0] != "")
        {
            //gets the Instances_Of_Scenes unload function and uses it here
            StartCoroutine("UnloadScene");
        }
    }

    //unloader
    IEnumerable UnloadScene()
    {
        yield return new WaitForSeconds(.10f);
        for (int i = 0; i < unloadName.Length; i++)
        {
            Instances_Of_Scenes.Instance.Unload(unloadName[i]);
        }
    }
}
