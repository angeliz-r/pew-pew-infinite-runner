using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTileY : MonoBehaviour
{
    private bool isUp;
    private float speed;

    public void Awake()
    {
        speed = Random.Range(3, 6);
    }
    public void SidetoSide()
    {
        //move towards
        if (isUp)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(-Vector3.up * speed * Time.deltaTime);
        }

        //check where to move
        if (transform.position.y >= 3.0f)
        {
            isUp = false;
        }
        if (transform.position.y <= -0.3f)
        {
            isUp = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        SidetoSide();
    }
}
