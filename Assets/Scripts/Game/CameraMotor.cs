using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    //camera follow things
    [SerializeField]private Transform lookAt; //serialized so we can just grab and drag the player transform to inspector.
    public Rigidbody PlayerRB;
    private Vector3 startOffset;
    private Vector3 moveVector;

    //cam animation
    private float transition = 0.0f;
    protected float animationDuration = 2.0f;
    private Vector3 animationOffset = new Vector3(0, 5, 5);
    private bool animDone;

    private void Start()
    {
        startOffset = transform.position - lookAt.position;
        EventManager.current.updateEvent += UpdateCamera;
    }

    private void OnDestroy()
    {
        EventManager.current.updateEvent -= UpdateCamera;
    }
    void UpdateCamera()
    {
        moveVector = lookAt.position + startOffset; //camera pos = player pos

        //keep camera centered;
        moveVector.x = 0;
        //restrict up and down movement for smoother camera
        moveVector.y = Mathf.Clamp(moveVector.y, 3, 5);
        
        if (transition > 1.0f) //move normal
        {
            transform.position = moveVector;
        }
        else 
        {
            //animation 
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(lookAt.position + Vector3.up);
        } 
    }

    public float getAnimDuration ()
    {
        return animationDuration;
    }
}
