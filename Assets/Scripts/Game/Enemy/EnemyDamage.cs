using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyDamage : MonoBehaviour
{
    public int health;
    public TextMeshPro healthAmt;
    public GameObject UIObject;
    public GameObject destroyEffect;
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
            if (health == 0)
            {
                DestroyObject();
            }
        }
    }

    void DestroyObject()
    {
        GameObject go = Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(UIObject);
        Destroy(this.gameObject);

    }

}
