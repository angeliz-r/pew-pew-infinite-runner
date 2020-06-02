using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTile : MonoBehaviour
{
    private bool isRight;
    private float speed;
    public void Awake()
    {
        speed = Random.Range(3, 6);
    }

    private void Start()
    {
        EventManager.current.updateEvent += SidetoSide;
    }

    private void OnDestroy()
    {
        EventManager.current.updateEvent -= SidetoSide;
    }
    public void SidetoSide ()
    {
        //move towards
        if (isRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(-Vector3.right * speed * Time.deltaTime);
        }

        //check where to move
        if (transform.position.x >= 3.0f)
        {
            isRight = false;
        }
        if (transform.position.x <= -3.0f)
        {
            isRight = true;
        }
    }
}
