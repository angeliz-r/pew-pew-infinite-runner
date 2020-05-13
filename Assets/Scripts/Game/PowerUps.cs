using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public Shoot ammoScript;
    public void AddAmmo()
    {
        ammoScript.ammo += 10;
    }
}
