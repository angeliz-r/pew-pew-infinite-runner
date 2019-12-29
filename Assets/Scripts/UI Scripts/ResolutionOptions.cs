using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class ResolutionOptions : MonoBehaviour
{
    Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;
    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        int currentResolutionIndex = 0;
        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }

        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetFullscreen (bool x)
    {
        Screen.fullScreen = x;
    }

    public void SetResolution(int x)
    {
        Resolution resolution = resolutions[x];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public AudioMixer mixer;
    public void SetVolume(float x)
    {
        mixer.SetFloat("MasterVol", x);
    }

    public void ToggleVolume (bool x)
    {
        if (x)
        {
            mixer.SetFloat("MasterVol", 0f);
        }
        else
        {
            mixer.SetFloat("MasterVol", -80f);
        }
    }
}
