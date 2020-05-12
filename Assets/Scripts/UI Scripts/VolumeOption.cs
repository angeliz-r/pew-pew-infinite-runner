using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeOption : MonoBehaviour
{
    public AudioMixer mixer;
    public void SetVolume(float x)
    {
        mixer.SetFloat("MasterVol", x);
    }

    public void ToggleVolume(bool x)
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
