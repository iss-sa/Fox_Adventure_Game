using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEditor;

public class AudioManager : MonoBehaviour
{
    // From Sound class
    public Sound[] sounds;

    // get instance if Audio Manager
    public static AudioManager instance;
    void Awake()
    {
        // if there are two Audio Managers, destroy one, keep other (only one needed)
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // keep current audio manager throughout all scenes
        DontDestroyOnLoad(gameObject);
        
        // instantiate 
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
        
    }

    // to play background sound constantly
    void Start()
    {
        Play("backgroundSound");
    }

    // Play function, so that a sound can be played in another class
    public void Play(string name) 
    {
        // find sound in list with name given
        Sound s = Array.Find(sounds, sound => sound.name == name);

        // if exists, play sound, if not send message
        if (s != null)
        {
            s.source.Play();
        }
        else
        {
            Debug.Log(name + " not found (check also in gameObject AudioManager name)");
        }
    } // FindObjectOfType<AudioManager>().Play("nameofAudioFile");
    
    // same logic as Play(), only for pausing sound
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
    } // FindObjectOfType<AudioManager>().Play("nameofAudioFile");
}
