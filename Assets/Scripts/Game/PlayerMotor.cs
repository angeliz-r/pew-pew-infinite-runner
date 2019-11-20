
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;

    //movement properties
    private Vector3 moveVector;
    private float speed = 4.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;

    public bool isDead = false;

    //get anim duration & other properties from camera motor
    [SerializeField]private GameObject cameraObj;
    private CameraMotor cameraMotorScript;

    private float animationDuration;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        cameraMotorScript = cameraObj.GetComponent<CameraMotor>();
        animationDuration = cameraMotorScript.getAnimDuration();
    }

    void Update()
    {
        if (isDead)
        {
            return;
        }
        if (Time.time < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return; //exit update to let camera anim play
        }

        //reset vector per frame
        moveVector = Vector3.zero;

        //x - left & right movement
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed; //control character w/ standard input keys

        if (controller.isGrounded) //check if player is on the ground
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime; //fall if not grounded
        }

        //y - gravity
        moveVector.y = verticalVelocity;

        //z - move forward constantly
        moveVector.z = speed; 

        controller.Move(moveVector * Time.deltaTime);
    }

    public void SetSpeed(int modifier)
    {
        speed = 6.0f + modifier;
    }

    private void OnControllerColliderHit (ControllerColliderHit hit)
    {
       if (hit.point.z > transform.position.z + controller.radius)
        {
           Death();
        }
    }
    public void Death()
    {
        isDead = true;
    }
}
