using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public TimeManager timeScript;
    public Shoot ammoScript;

    private void Awake()
    {
        
    }
    public void AddAmmo()
    {
        ammoScript.ammo += 10;
    }

    public void SlowMotion()
    {
        timeScript.SlowMotion();
    }
}
