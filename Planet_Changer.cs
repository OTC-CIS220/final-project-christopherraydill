using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet_Changer : MonoBehaviour {

    //you pick the materials to randomize bettween
    public Material[] materials;

    //sets to the default color and material for the main menu
    public bool isDefault;

    //this referances this script
    private Planet_Changer exp;

    //default color
    //note has to be a flout to look right
    private Color paintedDefault = new Color(.6f, .14f, .8f);

    // Use this for initialization
    void Start()
    {
        //gets the component for this script
        exp = GetComponent<Planet_Changer>();

        //changes the material from 0 to your selection
        gameObject.GetComponent<MeshRenderer>().material = materials[Random.Range(0, materials.Length)];

        //sets the color
        if (!isDefault)
        {
            // rgb random number from 0 to twenty-three
            float r = Random.Range(0, 23);
            float g = Random.Range(0, 23);
            float b = Random.Range(0, 23);

            //changes the color based on the random numbers
            gameObject.GetComponent<Renderer>().material.color = new Color(r, g, b);
        }
        else
        {
            //changes the color to default
            gameObject.GetComponent<Renderer>().material.color = paintedDefault;
        }

        //destroys this script
        Destroy(exp);
    }
}
