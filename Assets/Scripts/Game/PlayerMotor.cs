
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private GameObject btnControls;
    [SerializeField] private Score scoreScript;
    [SerializeField] private PowerUps powerUpScript;
    //movement properties
    private CharacterController controller;
    private Vector3 moveVector;
    private Vector3 targetPos;


    private int desiredLane = 1; //left = 0, middle = 1, right = 2
    private float speed;
    private const float TURN_SPEED = .6f;
    private const float LANE_DIST = 1.2f;

    //jump things
    //private float jumpForce = 3.0f;
    //private Vector3 jump;

    private float verticalVelocity;
    private float gravity = 12.0f;

    [HideInInspector]public Rigidbody rb;

    //public Swipe swipeScript;

    private bool isRight;

    //death
    public bool isDead = false;

    private float animationDuration = 2.0f;

    void Awake()
    {
        isRight = false;
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        //swipeScript = this.GetComponent<Swipe>();
    }

    void Update()
    {
        //restrict
        if (Time.timeSinceLevelLoad < animationDuration)
        {
            btnControls.SetActive(false);
            moveVector = Vector3.zero;
            moveVector.y = .5f;
            targetPos = transform.position.z * Vector3.forward;
            return; //exit update to let camera anim play
        }
        else if (Time.timeSinceLevelLoad > animationDuration)
        {
            Movement();
            btnControls.SetActive(true);
        }
        if (isDead)
        {
            return;
        }

    }

    public void Movement()
    {
        #region old code
        ////jump control
        //if (isGrounded && swipeScript.SwipeUp == true)
        //{
        //    rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        //    isGrounded = false;
        //}

        //shitty swipe controls
        //if (swipeScript.SwipeRight)
        //{
        //    StartCoroutine(Move("right"));
        //}
        //else if (swipeScript.SwipeLeft)
        //{
        //    StartCoroutine(Move("left"));
        //}
        //else
        //{
        //    StopCoroutine(Move("left"));
        //    StopCoroutine(Move("right"));
        //}

        //tilt controls that didnt work lmao
        //moveVector.x = Input.acceleration.x * (speed - 1) * Time.fixedDeltaTime;
        //moveVector = new Vector3(Mathf.Clamp(transform.position.x, -4f, 4f), moveVector.y);
        //rb.velocity = new Vector3(moveVector.x, moveVector.y);

        //old shit
        //moveVector.z = Vector3.forward.z;
        //rb.MovePosition(rb.position + moveVector * speed * Time.fixedDeltaTime);
        #endregion
        //determine where to move
         
        //move forward
        targetPos = transform.position.z * Vector3.forward;

        //move L or R
        if (desiredLane == 0)
        {
            targetPos += Vector3.left * LANE_DIST;
        }
        else if (desiredLane == 2)
        {
            targetPos += Vector3.right * LANE_DIST;
        }
        //move smoothly
        moveVector = Vector3.zero;
        moveVector.x = (targetPos - transform.position).normalized.x * speed;

        //check gravity
        if (IsGrounded())
        {
            verticalVelocity = 0.1f;

            //jump can be in here
            //input button
                //verticalVelocity = jumpForce;
        }
        else
        {
            verticalVelocity -= (gravity * Time.deltaTime);

            //fastfall can be here
            //input button
                //verticalVelocity = -jumpForce;
        }
        moveVector.y =verticalVelocity;
        moveVector.z = speed;



        //move player
        controller.Move(moveVector * Time.deltaTime);

        //rotate when turning
        
        //Vector3 dir = controller.velocity;
        //if (dir != Vector3.zero)
        //{
        //    dir.y = 0;
        //    transform.forward = Vector3.Lerp(transform.forward, dir, TURN_SPEED);
        //}

    }

    void MoveLR()
    {
        desiredLane += (isRight) ? 1 : -1;
        desiredLane = Mathf.Clamp(desiredLane, 0, 2);
    }

    public void MoveLeft()
    {
        isRight = false;
        MoveLR();

    }

    public void MoveRight()
    {
        isRight = true;
        MoveLR();
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    isGrounded = true;
    //}
    public bool IsGrounded()
    {
        Ray groundRay = new Ray(
            new Vector3(controller.bounds.center.x,
            (controller.bounds.center.y - controller.bounds.extents.y) + 0.2f,
            controller.bounds.center.z),
            Vector3.down);

        //Debug.DrawRay(groundRay.origin, groundRay.direction, Color.cyan, 1.0f);
        if(Physics.Raycast(groundRay, 0.2f + 0.1f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void SetSpeed(int modifier)
    {
        speed = 6.0f + modifier;
    }

    #region Player Death
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "OutZone")
        {
            Death();
        }

        if (other.gameObject.tag =="Coin")
        {
            Destroy(other.gameObject);
            scoreScript.AddScore();
        }

        if(other.gameObject.tag =="Ammo")
        {
            Destroy(other.gameObject);
            powerUpScript.AddAmmo();
        }

        if (other.gameObject.tag =="Slow")
        {
            Destroy(other.gameObject);
            powerUpScript.SlowMotion();
        }
    }
    public void Death()
    {
        isDead = true;
    }
    #endregion
}
