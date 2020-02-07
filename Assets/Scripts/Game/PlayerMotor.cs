
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    //movement properties
    private Vector3 moveVector;
    private float speed = 7.0f;

    //jump things
    private float jumpForce = 3.0f;
    private Vector3 jump;
    public bool isGrounded;

    [HideInInspector]public Rigidbody rb;

    public Swipe swipeScript;
    private Vector3 moveLeft;
    private Vector3 moveRight;
    private bool isRight;

    private Vector3 startPos;
    private Vector3 endPos;
    private float moveTime = 0f;
    private float moveDuration = 0.1f;

    //death
    public bool isDead = false;

    private float animationDuration = 2.0f;

    void Awake()
    {
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        moveLeft = new Vector3(-0.4f, 0.0f, 0.0f);
        moveRight = new Vector3(0.4f, 0.0f, 0.0f);
        isRight = false;
        rb = this.GetComponent<Rigidbody>();
        swipeScript = this.GetComponent<Swipe>();
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
    }

    private void FixedUpdate()
    {
        MovementUpdate();
    }

    public void MovementUpdate()
    {
        if (Time.timeSinceLevelLoad > animationDuration)
        {
            //jump control
            if (isGrounded && swipeScript.SwipeUp == true)
            {
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }

            if (swipeScript.SwipeRight)
            {
                StartCoroutine(Move("right"));
            }
            else if (swipeScript.SwipeLeft)
            {
                StartCoroutine(Move("left"));
            }
            else
            {
                StopCoroutine(Move("left"));
                StopCoroutine(Move("right"));
            }
            //tilt controls that didnt work lmao
            //moveVector.x = Input.acceleration.x * (speed - 1) * Time.fixedDeltaTime;
            //moveVector = new Vector3(Mathf.Clamp(transform.position.x, -4f, 4f), moveVector.y);
            //rb.velocity = new Vector3(moveVector.x, moveVector.y);

            moveVector.z = Vector3.forward.z;
            rb.MovePosition(rb.position + moveVector * speed * Time.fixedDeltaTime);
           

        }
    }

    private IEnumerator Move (string dir)
    {
        switch (dir)
        {
            case "left":
                moveTime = 0f;
                startPos = transform.position;
                endPos = new Vector3(startPos.x - .1f, transform.position.y, transform.position.z);

                while (moveTime < moveDuration)
                {
                    moveTime += Time.deltaTime;
                    transform.position = Vector2.Lerp(startPos, endPos, moveTime / moveDuration);
                    yield return null;
                }
                break;
            case "right":
                moveTime = 0f;
                startPos = transform.position;
                endPos = new Vector3(startPos.x + .1f, transform.position.y, transform.position.z);

                while (moveTime < moveDuration)
                {
                    moveTime += Time.deltaTime;
                    transform.position = Vector2.Lerp(startPos, endPos, moveTime / moveDuration);
                }
                break;

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
