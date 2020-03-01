using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Harmony;

public class PauseMenuController : MonoBehaviour
{
    private GameObject currentlySelected;

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
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
