using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Audio
{
    public enum Clip { Click, GlassFully, Fall, Win }
    public Clip clip;
    public AudioClip audio;
}

public class AudioManager : MonoBehaviour
{
    public List<Audio> sounds;
    [SerializeField] public AudioSource source;

    public AudioClip GetClip(Audio.Clip type)
    {
        return sounds.Find(s => s.clip.Equals(type)).audio;
    }

    public void Play(Audio.Clip type, float volume = 1, float stereoPan = 0)
    {
        source.clip = GetClip(type);
        source.volume = volume;
        source.panStereo = stereoPan;
        source.Play();
        GetComponent<AudioSource>().PlayOneShot(source.clip);
    }
}