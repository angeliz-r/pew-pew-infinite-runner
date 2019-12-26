using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingProgressBar : MonoBehaviour
{
    private Image image;
    private GameObject loading;
    private void Awake()
    {
        loading = GameObject.Find("load img");
        image = loading.GetComponent<Image>();
    }
    private void Update()
    {
        image.fillAmount = Loader.GetLoadingProgress();
    }
}