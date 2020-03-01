using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Harmony;
using UnityEngine.EventSystems;

public class GameOverMenuController : MonoBehaviour
{
    private GameObject currentlySelected;

    private void OnEnable()
    {
        Finder.ManageMenus.IsGameOverMenuOpen = true;
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
        Finder.ManageMenus.IsGameOverMenuOpen = false;
    }

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject != null)
        {
            currentlySelected = EventSystem.current.currentSelectedGameObject;
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(currentlySelected);
        }
    }
}
