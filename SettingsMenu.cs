using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

    //this is what our volume is hooked up to
    public AudioMixer audioMixer;

    //the gui of a dropdown
    public Dropdown resolutionDropdown;

    //the gui of a dropdown for Quality Settings of the game
    public Dropdown qualityDropdown;

    //used to get the screens resolutions
    Resolution[] resolutions;

    private void Start()
    {

        //sets the gui Quality Settings of the game
        qualityDropdown.value = QualitySettings.GetQualityLevel();

        //get the screens resolutions
        resolutions = Screen.resolutions;

        //clear dropdown
        resolutionDropdown.ClearOptions();

        //make a list of options
        List<string> options = new List<string>();

        //the current resolution index
        int currentResolutionIndex = 0;

        //this finds the current resolution index og the game
        for (int i = 0; i < resolutions.Length; i++)
        {
            //creates a string out of the resolutions
            string option = resolutions[i].width + " X " + resolutions[i].height;

            //adds options to the list
            options.Add(option);

            //set the current resolution index
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        //setup for the resolutionDropdown, then it's refreshed
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

    //sets the resolution 
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    //sets the volume
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    //sets the quality level
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    //sets fullscreen
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
