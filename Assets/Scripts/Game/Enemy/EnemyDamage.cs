using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyDamage : MonoBehaviour
{
    public int health;
    //[SerializeField] private TextMeshProUGUI healthAmt;
    //insert health num UI
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (health > 0)
            {
                --health;

            }
            else
            {
                DestroyObject();
            }
        }
    }

    void DestroyObject()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }

}
