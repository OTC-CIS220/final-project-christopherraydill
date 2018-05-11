using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Scene_Shifter : MonoBehaviour {

    //an audio source
    private AudioSource _audioSource;

    // Use this for awake
    private void Awake()
    {

        //this object can't be destroyed
        DontDestroyOnLoad(transform.gameObject);

        //get the component for this audio source
        _audioSource = GetComponent<AudioSource>();

        //keeps only one music tag object between scenes
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1)
            Destroy(this.gameObject);
    }

    //plays music
    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    //stops music
    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
