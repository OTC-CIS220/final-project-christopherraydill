using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Planet : MonoBehaviour
{
    //gets planet types
    public GameObject[] planets;

    // Use this for initialization
    void Start()
    {

        //gets current position
        Vector3 spawn = transform.position;

        //creates the random object at spawn, with this objects rotation 
        Instantiate(planets[Random.Range(0, 8)], spawn, transform.rotation);

        //destroys this script
        DestroyScriptInstance();

    }

    //destroys this script
    void DestroyScriptInstance()
    {
        Destroy(this);
    }
}
