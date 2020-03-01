using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Harmony;

[Findable(R.S.Tag.MainController)]
public class ManageMenus : MonoBehaviour
{
    public bool IsPauseMenuOpen { get; set; }
    public bool IsGameOverMenuOpen { get; set; }
    public event EventHandler GameOver;

    public void NotifyGameOver()
    {
        GameOver?.Invoke();
    }
}
