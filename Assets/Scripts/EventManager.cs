using UnityEngine;
using System;
public class EventManager : MonoBehaviour
{
    public static EventManager current;

    private void Awake()
    {
        current = this;
    }

    void Update()
    {
        UpdateStatus();
    }

    public event Action updateEvent;
    public void UpdateStatus()
    {
        if (updateEvent != null)
            updateEvent();
    }

}
