using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyDamage : MonoBehaviour
{
    public int health;
    public TextMeshPro healthAmt;
    public GameObject UIObject;
    //insert health num UI

    void UpdateHealth()
    {
        healthAmt.text = health.ToString();
    }

    private void Start()
    {
        EventManager.current.updateEvent += UpdateHealth;
    }

    private void OnDestroy()
    {
        EventManager.current.updateEvent -= UpdateHealth;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Projectile>())
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
        Destroy(UIObject);
        Destroy(gameObject);

    }

}
