using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayAmmoCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoDisplay;
    public Shoot shootProjectile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAmmoCount();
    }
    void UpdateAmmoCount()
    {
        if (shootProjectile.ammo > 0)
        {
            ammoDisplay.text = "x" + shootProjectile.ammo.ToString();
        }
        else
        {
            ammoDisplay.text = "x0";
            ammoDisplay.color = Color.red;
        }

    }

}
