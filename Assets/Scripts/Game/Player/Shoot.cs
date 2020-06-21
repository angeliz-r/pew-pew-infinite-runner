using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public int ammo = 20;
    [SerializeField] private GameObject bullet;
    public GameObject secondOrigin;
    private float speed = 200f;
    private bool shoot;

    private void Start()
    {
        EventManager.current.updateEvent += ShootBullets;
    }

    private void OnDestroy()
    {
        EventManager.current.updateEvent -= ShootBullets;
    }

    void ShootBullets()
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
        return;
    }
    public void ShootProjectile()
    {
        if (ammo > 0)
        {
            GameObject projectile = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            Rigidbody projectileRB = projectile.GetComponent<Rigidbody>();
            projectileRB.AddForce(Vector3.forward * speed);

            GameObject projectile2 = Instantiate(bullet, secondOrigin.transform.position, Quaternion.identity) as GameObject;
            Rigidbody projectileRB2 = projectile2.GetComponent<Rigidbody>();
            projectileRB2.AddForce(Vector3.forward * speed);

            ammo -= 2;
            return;
        }
        else
        {
            return;
        }
    }
}
