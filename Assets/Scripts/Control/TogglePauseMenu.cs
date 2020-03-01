using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TogglePauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    private void ToggleMenu()
    {
        if (!menu.activeInHierarchy)
        {
            menu.SetActive(true);
        }
    }
}
