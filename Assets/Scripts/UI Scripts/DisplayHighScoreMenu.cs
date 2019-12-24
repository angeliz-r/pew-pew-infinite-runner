﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayHighScoreMenu : MonoBehaviour
{
    public TextMeshProUGUI text;
  
    void Start()
    {
        text.text = GameManager.instance.GetHighScore().ToString();
    }
}