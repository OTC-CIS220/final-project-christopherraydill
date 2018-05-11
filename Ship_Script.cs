using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship_Script : MonoBehaviour {

    //game objects to control
    public GameObject leftIgnition;
    public GameObject rightIgnition;
    public GameObject first;
    public GameObject third;
    public GameObject shipCamera;
    public GameObject exitMenu;

    //change between 1st person and 3rd person
    bool toggleView;

    //change between showing the exit game and not
    bool toggleExit;

    // Update is called once per frame
    void Update () {

        //toggles color to look like ignition
        if (Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("w") || Input.GetKey("s"))
        {
            leftIgnition.GetComponent<Renderer>().material.color = new Color(255f, 0f, 0f);
            rightIgnition.GetComponent<Renderer>().material.color = new Color(255f, 0f, 0f);
        }
        else
        {
            leftIgnition.GetComponent<Renderer>().material.color = new Color(193f, 188f,0f);
            rightIgnition.GetComponent<Renderer>().material.color = new Color(193f, 188f, 0f);
        }

        //change between showing the exit game and not
        if (Input.GetKey(KeyCode.Escape))
        {
            if (toggleExit)
            {
                exitMenu.active = true;
                toggleExit = false;
            }
            else
            {
                exitMenu.active = false;
                toggleExit = true;
            }
        }

        //change between 1st person and 3rd person
        if (Input.GetKey("t"))
        {
            if (toggleView)
            {
                shipCamera.transform.position = first.transform.position;
                toggleView = false;
            }
            else
            {
                shipCamera.transform.position = third.transform.position;
                toggleView = true;
            }
        }

        //all of this is for movement
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 600.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }
}
