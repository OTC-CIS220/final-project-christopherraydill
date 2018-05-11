using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove_Extra_Music : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //finds objects with the Music tag and destroys them
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        Destroy(objs[0]);
    }
}
