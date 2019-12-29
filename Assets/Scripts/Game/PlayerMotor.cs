
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    //movement properties
    private Vector3 moveVector;
    private float speed = 7.0f;

    //jump things
    private float jumpForce = 2.0f;
    private Vector3 jump;
    public bool isGrounded;
    public Rigidbody rb;

    //death
    public bool isDead = false;

    private float animationDuration = 2.0f;

    void Awake()
    {
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        rb = this.GetComponent<Rigidbody>();
        
    }

    void Update()
    {
        //restrict
        if (Time.timeSinceLevelLoad < animationDuration)
        {
           rb.velocity = Vector3.forward * speed * Time.deltaTime;
            return; //exit update to let camera anim play
        }
        if (isDead)
        {
            return;
        }
        MovementUpdate();
    }

    public void MovementUpdate()
    {
        if (Time.timeSinceLevelLoad > animationDuration)
        {
            moveVector.x = Input.GetAxis("Horizontal");
            moveVector.z = Vector3.forward.z;
            //jump controls
            if (isGrounded && Input.GetButtonDown("Jump")) 
            {
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }

            rb.MovePosition(rb.position + moveVector * speed * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    public void SetSpeed(int modifier)
    {
        speed = 6.0f + modifier;
    }

    #region Player Death
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "OutZone")
        {
            Death();
        }
    }
    public void Death()
    {
        isDead = true;
    }
    #endregion
}
