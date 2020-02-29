using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonController : MonoBehaviour
{
    public void PlayGame()
    {
        Harmony.Finder.SceneBundleLoader.Switch(Harmony.Finder.SceneBundlesReference.GetSceneBundleByName("Game"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
