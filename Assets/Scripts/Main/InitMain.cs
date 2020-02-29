using Harmony;
using UnityEngine;

public class InitMain : MonoBehaviour
{
    private void Start()
    {
        Finder.SceneBundleLoader.Load(Finder.SceneBundlesReference.GetSceneBundleByName("MainMenu"));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Finder.SceneBundleLoader.Switch(Finder.SceneBundlesReference.GetSceneBundleByName("Test"));
        }
    }
}
