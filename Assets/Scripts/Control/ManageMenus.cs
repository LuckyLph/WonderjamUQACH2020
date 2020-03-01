using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Harmony;

[Findable(R.S.Tag.MainController)]
public class ManageMenus : MonoBehaviour
{
    public bool IsPauseMenuOpen;
    public bool IsGameOverMenuOpen;
    public event EventHandler GameOver;
}
