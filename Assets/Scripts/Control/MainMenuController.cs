using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Harmony;

public class MainMenuController : MonoBehaviour
{
    private GameObject currentlySelected;

    private void Start()
    {
       AudioManager.instance.PlaySound("MenuTheme");
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