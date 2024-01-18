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

    [Header("Level Selector")]
    [SerializeField] private GameObject levelSelection;

    [Header("Bools")]
    [SerializeField] private bool startPressed;
    [SerializeField] private bool playPressed;

    #endregion

    #region METHODS

    private void Start()
    {
        background.SetActive(true);
        toolbar.SetActive(true);
        windowsTab.SetActive(false);
        levelSelection.SetActive(false);

        startPressed = false;
        playPressed = false;
    }

    private void Update()
    {

    }

    #region BUTTONS

    public void StartButton()
    {
        if (startPressed)
        {
            windowsTab.SetActive(false);
            startPressed = false;
        }
        else
        {
            windowsTab.SetActive(true);
            startPressed = true;
        }
    }

    public void PlayButton()
    {
        Debug.Log("Pressed");
        if (playPressed)
        {
            levelSelection.SetActive(false);
            playPressed = false;
        }
        else
        {
            levelSelection.SetActive(true);
            playPressed = true;
        }
    }

    #endregion

    #endregion
}
