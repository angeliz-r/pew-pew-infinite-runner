using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemyDamage : MonoBehaviour
{
    public enum EnemyType { Wall, Shoot, Moving, Big };
    public EnemyType _type;
    private Score scoreManager;
    public int health;
    [Header("UI Elements")]
    public TextMeshPro healthAmt;
    public GameObject UIObject;
    public GameObject destroyEffect;
    public GameObject popup;
    //insert health num UI

    void Awake () 
    {
        scoreManager = FindObjectOfType<Score>();
        if (_type == EnemyType.Wall)
        {
            popup.GetComponent<TextMeshPro>().text = "+15";
        }
        else if (_type == EnemyType.Moving)
        {
            popup.GetComponent<TextMeshPro>().text = "+50";
        }
        else if (_type == EnemyType.Shoot)
        {
            popup.GetComponent<TextMeshPro>().text = "+150";
        }
        else if (_type == EnemyType.Big)
        {
            popup.GetComponent<TextMeshPro>().text = "+45";
        }
    }
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
                if (_type == EnemyType.Wall)
                {
                    scoreManager.AddScore(15);
                }
                else if (_type == EnemyType.Moving)
                {
                    scoreManager.AddScore(50);
                }
                else if (_type == EnemyType.Shoot)
                {
                    scoreManager.AddScore(150);
                }
                else if (_type == EnemyType.Big)
                {
                    scoreManager.AddScore(45);
                }
                    DestroyObject();
            }
        }
    }

    void DestroyObject()
    {
        popup.SetActive(true);
        GameObject go = Instantiate(destroyEffect, transform.position, Quaternion.identity);
        GameObject pts = Instantiate(popup, transform.position, Quaternion.identity);
        Destroy(UIObject);
        Destroy(this.gameObject);

    }

}
