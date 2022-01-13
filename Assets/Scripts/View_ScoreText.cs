using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class View_ScoreText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textMeshProUGUI;

    public void SetScore(string msg)
    {
        _textMeshProUGUI.text = msg;
    }
}
