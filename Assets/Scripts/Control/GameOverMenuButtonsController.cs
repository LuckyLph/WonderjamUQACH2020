using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Harmony;

public class GameOverMenuButtonsController : MonoBehaviour
{

    public void Restart()
    {
        Finder.SceneBundleLoader.Reload(Finder.SceneBundlesReference.GetSceneBundleByName("Game"));
    }

    public void QuitGame()
    {
        Finder.ManageMenus.IsGameOverMenuOpen = false;
        Time.timeScale = 1;
        Finder.SceneBundleLoader.Switch(Finder.SceneBundlesReference.GetSceneBundleByName("MainMenu"));
    }
}
