using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private float deadzone = 100.0f;
    private bool tap, swipeUp, swipeDown, swipeLeft, swipeRight;
    private float sqrDeadzone;

    private Vector2 swipeDelta;
    private Vector2 startTouch;
    private float lastTap;

    public bool Tap { get { return tap; } }
    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }

    // Start is called before the first frame update
    void Start()
    {
        sqrDeadzone = deadzone * deadzone;
    }

    // Update is called once per frame
    void Update()
    {
        //reset
        tap = swipeUp = swipeDown = false;
#if UNITY_EDITOR
        UpdateStandalone();
#endif
#if UNITY_ANDROID
        UpdateMobile();
#endif
    }

    private void UpdateStandalone ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            startTouch = Input.mousePosition;
            lastTap = Time.time;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            startTouch = swipeDelta = Vector2.zero;
        }

        //reset distance, get new swipeDelta
        swipeDelta = Vector2.zero;

        if (startTouch != Vector2.zero && Input.GetMouseButton(0))
        {
            swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }

        if (swipeDelta.sqrMagnitude > sqrDeadzone)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x > 0)
                {
                    swipeLeft = true;
                }

                else
                {
                    swipeRight = true;
                }
            }
            else
            {
                //up down swipe
                if (y < 0)
                {
                    swipeDown = true;
                }
                else
                {
                    swipeUp = true;
                    //Debug.Log("SWIPE UP");
                }
            }

            startTouch = swipeDelta = Vector2.zero;
        }

    }
    private void UpdateMobile()
    {
        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                startTouch = Input.mousePosition;
                lastTap = Time.time;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                startTouch = swipeDelta = Vector2.zero;
            }
        }

        swipeDelta = Vector2.zero;

        if (startTouch != Vector2.zero && Input.touches.Length != 0)
        {
            swipeDelta = Input.touches[0].position - startTouch;
        }

        if (swipeDelta.sqrMagnitude > sqrDeadzone)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x > 0)
                {
                    swipeLeft = true;
                }

                else
                {
                    swipeRight = true;
                }
            }
            else
            {
                //up down swipe
                if (y < 0)
                {
                    swipeDown = true;
                }
                else
                {
                    swipeUp = true;
                    //Debug.Log("SWIPE UP");
                }
            }

            startTouch = swipeDelta = Vector2.zero;
        }
    }
}
