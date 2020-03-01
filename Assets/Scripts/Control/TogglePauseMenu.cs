using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Harmony;

public class TogglePauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;

    [SerializeField]
    private InputAction pauseAction;

    private void OnEnable()
    {
        pauseAction.performed += PauseActionPerformed;
        pauseAction.Enable();
    }

    private void OnDisable()
    {
        pauseAction.performed -= PauseActionPerformed;
        pauseAction.Disable();
    }

    private void PauseActionPerformed(InputAction.CallbackContext obj)
    {
        ToggleMenu();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    ToggleMenu();
        //}
    }

    private void ToggleMenu()
    {
        if (!menu.activeInHierarchy && !Finder.ManageMenus.IsGameOverMenuOpen)
        {
            menu.SetActive(true);
        }
        else
        {
            menu.SetActive(false);
        }
    }
}
