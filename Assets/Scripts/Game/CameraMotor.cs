using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CameraMotor : MonoBehaviour
{
    //camera follow things
    [SerializeField]private Transform lookAt; //serialized so we can just grab and drag the player transform to inspector.
    public Rigidbody PlayerRB;
    private Vector3 startOffset;
    private Vector3 moveVector;

    //cam animation
    private float transition = 0.0f;
    protected float animationDuration = 4.0f;
    private Vector3 animationOffset = new Vector3(0, 5, 5);
    private bool animDone;

    [Header("UI Ready")]
    public GameObject readyTextObj;
    public TextMeshProUGUI readyText;
    public GameObject instructionObj;
    public GameObject initPos;
    public GameObject botPos;
    public GameObject BGoverlay;
    private void Start()
    {
        StartCoroutine(DisplayReady());
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

    IEnumerator DisplayReady()
    {
        BGoverlay.SetActive(true);
        instructionObj.SetActive(true);
        readyTextObj.SetActive(true);
        readyText.text = "3";
        LeanTween.moveY(readyTextObj, initPos.transform.position.y, .7f);
        LeanTween.moveY(instructionObj, botPos.transform.position.y, .7f);
        yield return new WaitForSeconds(1f);
        readyText.text = "2";
        yield return new WaitForSeconds(1f);
        readyText.text = "1";
        yield return new WaitForSeconds(1f);
        readyText.text = "GO!";
        yield return new WaitForSeconds(1f);
        instructionObj.SetActive(false);
        readyTextObj.SetActive(false);
        BGoverlay.SetActive(false);
        StopCoroutine(DisplayReady());
    }
}
