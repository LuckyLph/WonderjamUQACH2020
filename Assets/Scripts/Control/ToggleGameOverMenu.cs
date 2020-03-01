using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Harmony;

public class ToggleGameOverMenu : MonoBehaviour
{
    [SerializeField] GameObject menu;
    private void OnEnable()
    {
        Finder.ManageMenus.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        Finder.ManageMenus.GameOver -= OnGameOver;
    }

    private void OnGameOver()
    {
        ToggleMenu();
    }

    private void ToggleMenu()
    {
        menu.SetActive(true);
    }
}
