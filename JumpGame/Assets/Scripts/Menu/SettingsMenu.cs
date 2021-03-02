using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class SettingsMenu : MonoBehaviour
{

    Resolution[] resolutions;

    public TMP_Dropdown resolutionDropdown;

    private void Start()
    {

        resolutions = Screen.resolutions;



        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentRes = 0;
        for(int i = 0; i< resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " "+resolutions[i].refreshRate+"Hz";

           
                    options.Add(option);
           

            if (resolutions[i].height == Screen.height &&
                resolutions[i].width == Screen.width)
            {
                currentRes = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentRes;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetVolume(float volume)
    {

        FindObjectOfType<AudioManager>().SetVolume(volume);
    }


    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height,Screen.fullScreen);
    }
}
