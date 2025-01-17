﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private float _speed = 5f;
    private GameObject player;
    private Rigidbody rb;

    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        FindPlayer();
    }
    void FindPlayer()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        FindPlayer();
        ProjectileLaunch();
    }

    public void ProjectileLaunch()
    {
        //this.transform.Translate(-Vector3.forward * _speed * Time.deltaTime);
        rb.velocity = (player.transform.position - transform.position).normalized * _speed;
    }


    void DestroyProjectile()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }

    private void OnTriggerEnter(Collider other)
    {
        DestroyProjectile();
    }

}
