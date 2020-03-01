using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Harmony;

public class PauseMenuButtonController : MonoBehaviour
{
    [SerializeField] GameObject restartGroup;
    [SerializeField] GameObject quitGroup;
    [SerializeField] GameObject menu;

    public void UnPause()
    {
        restartGroup.SetActive(false);
        quitGroup.SetActive(false);
        menu.SetActive(false);
    }

    public void Restart()
    {
        Finder.SceneBundleLoader.Reload(Finder.SceneBundlesReference.GetSceneBundleByName("Game"));
        AudioManager.instance.StopSound("GameTheme");
    }

    public void QuitGame()
    {
        Finder.SceneBundleLoader.Switch(Finder.SceneBundlesReference.GetSceneBundleByName("MainMenu"));
        AudioManager.instance.StopSound("GameTheme");
    }
}
