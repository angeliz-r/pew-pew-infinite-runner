using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    [SerializeField] private GameObject bullet;
    private bool shoot;
    private GameObject player;
    public float minDistance;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(ShootProjectile());
    }
    void Update()
    {
        CalculateDistance();
    }

    void CalculateDistance()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance < minDistance)
        {
            shoot = true;
        }
        else
        {
            shoot = false;
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
