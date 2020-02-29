using UnityEngine;
using Harmony;

[Findable(R.S.Tag.MainController)]
public class SceneBundlesReference : MonoBehaviour
{
    [SerializeField] SceneBundle[] scenebundles;


    public SceneBundle[] SceneBundles
    {
        get => scenebundles;
    }

    public SceneBundle GetSceneBundleByName(string name)
    {
        for (int i = 0; i < scenebundles.Length; i++)
        {
            if (scenebundles[i].name == name)
            {
                return scenebundles[i];
            }
        }
        return null;
    }
}
