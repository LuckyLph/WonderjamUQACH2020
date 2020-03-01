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
        Finder.SceneBundleLoader.Unload(Finder.SceneBundlesReference.GetSceneBundleByName("Game"));
        Finder.SceneBundleLoader.Load(Finder.SceneBundlesReference.GetSceneBundleByName("Game"));
    }

    public void QuitGame()
    {
        Finder.SceneBundleLoader.Switch(Finder.SceneBundlesReference.GetSceneBundleByName("MainMenu"));
    }
}
