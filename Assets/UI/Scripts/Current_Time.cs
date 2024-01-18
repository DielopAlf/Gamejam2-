using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Current_Time : MonoBehaviour
{
    #region VARIABLES

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI text;

    [Header("Time")]
    [SerializeField] private float timeHour;
    [SerializeField] private float timeMinute;

    #endregion

    #region METHODS

    private void Update()
    {
        timeHour = DateTime.Now.Hour;
        timeMinute = DateTime.Now.Minute;

        text.text = timeHour + ":" + timeMinute;
    }

    #endregion
}
