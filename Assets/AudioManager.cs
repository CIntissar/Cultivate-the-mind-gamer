using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sounds[] soundsList;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy (gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (Sounds s in soundsList)
        {
            s.source = gameObject.AddComponent<AudioSource>(); //the sound that we're currently looking at
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }
    }
    void Start()
    {
        //play the music here
        //Play("music");
    }
    public void Play(string name)
    {
        Sounds s = Array.Find(soundsList, sounds => sounds.name == name);
        if(s == null)
        {
            return;
        }
        s.source.Play();
    }
}
