using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        foreach (var sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.playOnAwake = false;
            sound.audioSource.loop = sound.loop;
        }
    }
   

    public void Play(string name) 
    {
        Sound s = Array.Find(sounds,sound => sound.name == name);
        if (s==null)
        {
            Debug.Log("Null " + name + "List!");
        }

        s.audioSource.Play();
    }

    public void Stop() 
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Null " + name + "List!");
        }

        s.audioSource.Stop();
    }
}
