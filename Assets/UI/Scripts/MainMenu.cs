using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    #region VARIABLES

    [Header("Background")]
    [SerializeField] private GameObject background;

    [Header("Toolbar")]
    [SerializeField] private GameObject toolbar;

    [Header("Windows Tab")]
    [SerializeField] private GameObject windowsTab;

    [Header("Bools")]
    [SerializeField] private bool startpressed;

    #endregion

    #region METHODS

    private void Start()
    {
        background.SetActive(true);
        toolbar.SetActive(true);
        windowsTab.SetActive(false);

        startpressed = false;
    }

    private void Update()
    {

    }

    #region BUTTONS

    public void StartButton()
    {
        if (startpressed)
        {
            windowsTab.SetActive(false);
            startpressed = false;
        }
        else
        {
            windowsTab.SetActive(true);
            startpressed = true;
        }
    }

    #endregion

    #endregion
}
