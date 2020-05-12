using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _speed = 100f;

    // Update is called once per frame
    void Update()
    {
        ProjectileLaunch();
    }

    public void ProjectileLaunch()
    {
        this.transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }


    void DestroyProjectile()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }

    private void OnCollisionEnter(Collision collision)
    {
        DestroyProjectile();
    }
}
