using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreFloat : MonoBehaviour
{
    void Awake()
    {
        StartCoroutine(Anim());
    }

    IEnumerator Anim()
    {
        LeanTween.moveY(this.gameObject, this.transform.position.y + 4, 1.5f);
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
        StopCoroutine(Anim());
    }
}
