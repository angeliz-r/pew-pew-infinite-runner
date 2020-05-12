using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Shoot : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI ammoDisplay;
    public int ammo = 10;
    [SerializeField] private GameObject bullet;
    private float speed = 200f;
    private bool shoot;

    // Start is called before the first frame update
    void Awake()
    {
        ammoDisplay.text = "x" + ammo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (shoot)
        {
            ShootProjectile();
            shoot = false;
        }
    }

    public void PressToShoot()
    {
        shoot = true; 
        UpdateAmmoCount();
        return;
    }
    public void ShootProjectile()
    {
        if (ammo > 0)
        {
            GameObject projectile = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            Rigidbody projectileRB = projectile.GetComponent<Rigidbody>();
            projectileRB.AddForce(Vector3.forward * speed);
            ammo -= 1;
            return;
        }
        else
        {
            return;
        }
    }

    void UpdateAmmoCount()
    {
        if (ammo > 0)
        {
            ammoDisplay.text = "x" + ammo.ToString();
        }
        else
        {
            ammoDisplay.text = "x0";
            ammoDisplay.color = Color.red;
        }

    }

}
