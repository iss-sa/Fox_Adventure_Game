using UnityEngine.Audio;

using UnityEngine;

// so that you can see the variables in Inspector
[System.Serializable] 
public class Sound
{
    // For AudioManager:

    // name of sound clip
    public string name;
    // clip itself
    public AudioClip clip;

    // slide bar for volume
    [Range(0f, 1f)] 
    public float volume; 

    // if clip should be looped
    public bool loop;

    // Source of audio (not seen in inspector)
    [HideInInspector]
    public AudioSource source;

}
