using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public Transform initial;

    void OnEnable()
    {
        StartCoroutine(PlayAnimLoop());
    }


    IEnumerator PlayAnimLoop()
    {
        yield return new WaitForSeconds(1f);
        LeanTween.moveY(this.gameObject, initial.transform.position.y + 1,1f);
        yield return new WaitForSeconds(1f);
        LeanTween.moveY(this.gameObject, initial.transform.position.y - 1, 1f);
        yield return new WaitForSeconds(1f);
        StartCoroutine(PlayAnimLoop());
    }
}
