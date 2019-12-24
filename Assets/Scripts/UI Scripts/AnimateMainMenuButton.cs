using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateMainMenuButton : MonoBehaviour
{
    private float origSizex;
    private float origSizey;
    public GameObject button;
    public void Awake()
    {
        origSizex = this.GetComponent<Transform>().localScale.x;
        origSizey = this.GetComponent<Transform>().localScale.y;
    }
    public void AnimatedPress()
    {
        StartCoroutine(ButtonAnim());
    }

    IEnumerator ButtonAnim()
    {
        LeanTween.scale(button, new Vector2(this.transform.localScale.x + .2f, this.transform.localScale.y + .2f), .1f);
        yield return new WaitForSeconds(.1f);
        LeanTween.scale(button, new Vector2(origSizex, origSizey), .2f);
        yield return new WaitForSeconds(.1f);
        StopCoroutine(ButtonAnim());
    }
}
