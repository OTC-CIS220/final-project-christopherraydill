using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zombie : MonoBehaviour {

    //the player
    public GameObject player;

    //movement speed
    public float speed;

    //allows for animation to be played
    public Animator anim;

    //a gui element that tracks and shows hp
    public Text guiHealth;

    //gets the collision object and attacks a player
    private void OnCollisionEnter(Collision collision)
    {

        GameObject objColl = collision.gameObject;
        if (objColl.tag == "Player")
        {
            //Grrrrr Arrrg Attack
            anim.Play("attack");

        }

    }

    // Update is called once per frame
    void Update () {

        if (guiHealth.text != "Health 0")
        {

            //math to movetowards a point
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);

            //turns the object moving to face the movetowards point
            Vector3 targetDir = player.transform.position - transform.position;

            // The step size is equal to speed times frame time.
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
            Debug.DrawRay(transform.position, newDir, Color.red);

            // Move our position a step closer to the target.
            transform.rotation = Quaternion.LookRotation(newDir);

        }
        else
        {
            //stop at current point
            float step = 0 * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }

    }
}
