using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    [SerializeField] private GameObject bullet;
    private bool shoot;
    private GameObject player;
    private float minDistance = 10;


    void OnEnable()
    {
        FindPlayer();
    }

    void Start()
    {
        StartCoroutine(ShootProjectile());
    }

    void Update()
    {
        CalculateDistance();
        FindPlayer();
    }

    void FindPlayer()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
    }
    void CalculateDistance()
    {
        if (player !=null)
        {
            //float distance = Vector3.Distance(player.transform.position, transform.position);

            //if (distance < minDistance)
           //{
                shoot = true;
           // }
           //else
           // {
           //     shoot = false;
          //  }
        }

    }
    IEnumerator ShootProjectile()
    {
        yield return new WaitForSeconds(2f);
        if (shoot)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            StartCoroutine(ShootProjectile());
        }
    }
}
