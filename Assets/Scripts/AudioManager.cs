using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CustomAudio
{
    public string name;
    public AudioClip audioClip;
    public bool shouldLoop = false;
    [Range(0,1)]
    public float volume = 1;
    [Range(0.1f, 3)]
    public float pitch = 1;

    [HideInInspector]
    public AudioSource source;
}

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    public CustomAudio[] audioClips;

    public static AudioManager instance; //singleton

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        foreach (CustomAudio s in audioClips)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audioClip;
            s.source.loop = s.shouldLoop;
        }
    }

    public void PlaySound(string name)
    {
        CustomAudio s = System.Array.Find(audioClips, (customSound) => customSound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.volume = s.volume;
        s.source.pitch = s.pitch;

        s.source.Play();
    }

    public void StopSound()
    {
        CustomAudio s = System.Array.Find(audioClips, (customSound) => customSound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Stop();
    }



}
