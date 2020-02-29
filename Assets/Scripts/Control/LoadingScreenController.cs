using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Harmony;
using System;

public class LoadingScreenController : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;

    private void Awake()
    {
        loadingScreen.SetActive(false);
    }

    private void OnEnable()
    {
        Finder.SceneBundleLoader.OnSwitchingStarted += OnSceneBundleSwitchStart;
        Finder.SceneBundleLoader.OnSwitchingEnded += OnSceneBundleSwitchEnd;
    }

    private void OnDisable()
    {
        Finder.SceneBundleLoader.OnSwitchingStarted -= OnSceneBundleSwitchStart;
        Finder.SceneBundleLoader.OnSwitchingEnded -= OnSceneBundleSwitchEnd;
    }

    private void OnSceneBundleSwitchEnd(SceneBundle oldSceneBundle, SceneBundle newSceneBundle)
    {
        StartCoroutine(LoadingScreenDelayCoroutine());
    }

    private void OnSceneBundleSwitchStart(SceneBundle oldSceneBundle, SceneBundle newSceneBundle)
    {
        Time.timeScale = 0;
        loadingScreen.SetActive(true);
    }

    private IEnumerator LoadingScreenDelayCoroutine()
    {
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
        loadingScreen.SetActive(false);
    }
}
