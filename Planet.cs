using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

    //allows for point selection
    public GameObject RotationOfPoint;
    
    float y;
    // Update is called once per frame
    void Update () {

        //all to spin a planet around a point
        transform.RotateAround(RotationOfPoint.transform.position, -Vector3.up, 20 * Time.deltaTime);
        y += Time.deltaTime * 20;
        transform.rotation = Quaternion.Euler(0, y, 0);
    }
}
