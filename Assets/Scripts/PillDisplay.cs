using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PillDisplay : MonoBehaviour
{
    [SerializeField] private PlayerControls player;
    public TMP_Text pillDisplayText;
    string pillCountString;
    void Update()
    {
        pillCountString = player.pillCount.ToString();
        pillDisplayText.text = "x" + pillCountString;
    }
}
