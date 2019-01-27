using UnityEngine.Audio;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
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
            s.source.pitch = s.pitch;
            s.source.playOnAwake = s.playOnAwake;
            s.source.loop = s.loop;
        }
    }

    public void Play(String name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound with name = " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public Boolean IsPlaying(String name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound with name = " + name + " not found!");
            return false;
        }
        return s.source.isPlaying;
    }

    public void Stop(String name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound with name = " + name + " not found!");
            return;
        }
        s.source.Stop();
    }

    public Sound[] getSounds()
    {
        return sounds;
    }

    public List<Sound> getSpookySounds() {
        List<Sound> spookySounds = new List<Sound>();
        foreach (Sound s in getSounds())
        {
            if (s.RandomSound)
            {
                spookySounds.Add(s);
            }
        }
        return spookySounds;
    }
}
