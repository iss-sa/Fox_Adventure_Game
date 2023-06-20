using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEditor;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private bool _isPlaying = true;

    public static AudioManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
        
    }

    void Start()
    {
        Play("backgroundSound");
    }

    public void Play(string name) 
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            s.source.Play();
        }
        else
        {
            Debug.Log(name + " not found (check also in gameObject AudioManager name)");
        }
    } // FindObjectOfType<AudioManager>().Play("nameofAudioFile")
    
    public void Pause(string nameofAudioFile)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            s.source.Pause();
        }
        else
        {
            Debug.Log(name + " not found (check also in gameObject AudioManager name)");
        }
    } // FindObjectOfType<AudioManager>().Play("nameofAudioFile")
}
