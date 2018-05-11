using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    //sets max health
    public int health = 100;

    //track health
    public Text guiHealth;

    //is for activating animation
    private Animator an;

    //animation initator
    public AudioSource v;

    //animation itself
    public AudioClip death;

    //allows for one scream
    bool oneScream = false;

    //delays the inavitable... it slows death
    public float delay = 0f;

    // Use this for initialization
    void Start()
    {
        //component setup
        v = GetComponent<AudioSource>();
        an = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject getColl = collision.gameObject;
        if (getColl.tag == "enemy")
        {
            //enemy takes one health
            health--;
        }

        //if health equals zero less start death
        if (health <= 0)
        {

            //start the death of the player
            if (!oneScream)
            {
                an.Play("fallingback");
                v.PlayOneShot(death, 0.7F);
                Destroy(gameObject, an.GetCurrentAnimatorStateInfo(0).length + delay);
            }

            //scream one time
            oneScream = true;

        }

        //removes -1 error
        if (health < 0)
        {
            health = 0;
        }

        //updates text for health
        guiHealth.text = "Health " + health;

    }
}
