using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    #region VARIABLES

    [Header("Canvas")]
    [SerializeField] private GameObject canvas;

    [Header("Background")]
    [SerializeField] private GameObject background;

    [Header("Toolbar")]
    [SerializeField] private GameObject toolbar;

    [Header("Windows Tab")]
    [SerializeField] private GameObject windowsTab;

    [Header("Level Selector")]
    [SerializeField] private GameObject levelSelection;

    [Header("Controls")]
    [SerializeField] private GameObject controls;

    [Header("Credits")]
    [SerializeField] private GameObject credits;

    [Header("Configuration")]
    [SerializeField] private GameObject configuration;

    [Header("Bools")]
    [SerializeField] private bool startPressed;
    [SerializeField] private bool playPressed;
    [SerializeField] private bool controlsPressed;
    [SerializeField] private bool creditsPressed;
    [SerializeField] private bool configurationPressed;

    #endregion

    #region METHODS

    private void Start()
    {
        canvas.SetActive(true);
        background.SetActive(true);
        toolbar.SetActive(true);
        windowsTab.SetActive(false);
        levelSelection.SetActive(false);
        controls.SetActive(false);
        credits.SetActive(false);
        configuration.SetActive(false);

        startPressed = false;
        playPressed = false;
        controlsPressed = false;
        creditsPressed = false;
        configurationPressed = false;
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
        controls.SetActive(false);
        credits.SetActive(false);
        configuration.SetActive(false);
        controlsPressed = false;
        creditsPressed = false;
        configurationPressed = false;

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

    public void ControlsButton()
    {
        levelSelection.SetActive(false);
        credits.SetActive(false);
        configuration.SetActive(false);
        playPressed = false;
        creditsPressed = false;
        configurationPressed = false;

        if (controlsPressed)
        {
            controls.SetActive(false);
            controlsPressed = false;
        }
        else
        {
            controls.SetActive(true);
            controlsPressed = true;
        }
    }

    public void CreditsButton()
    {
        levelSelection.SetActive(false);
        controls.SetActive(false);
        configuration.SetActive(false);
        playPressed = false;
        controlsPressed = false;
        configurationPressed = false;

        if (creditsPressed)
        {
            credits.SetActive(false);
            creditsPressed = false;
        }
        else
        {
            credits.SetActive(true);
            creditsPressed = true;
        }
    }

    public void ConfigurationButton()
    {
        levelSelection.SetActive(false);
        controls.SetActive(false);
        credits.SetActive(false);
        playPressed = false;
        controlsPressed = false;
        creditsPressed = false;

        if (configurationPressed)
        {
            configuration.SetActive(false);
            configurationPressed = false;
        }
        else
        {
            configuration.SetActive(true);
            configurationPressed = true;
        }
    }

    #endregion

    #endregion
}
