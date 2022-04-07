using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sounds[] soundsList;
    Scene currentScene;
    void Awake()
    {
        string sceneName = currentScene.name;
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
    void Update()
    {
        // currentScene = SceneManager.GetActiveScene();
        // if(currentScene.name == "Ball'nBird")
        // {
        //     print("we're on scene 2 !");
        //     Play("ForestAmbiance");
        // }
        // else if(currentScene.name == "Dot on sea")
        // {
        //     StopPlaying("ForestAmbiance");
        //     Play("BeachAmbiance");
        // }
        // else if(currentScene.name == "GiantHead")
        // {
        //     StopPlaying("BeachAmbiance");
        //     Play("MountainAmbiance");
        // }
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
    public void StopPlaying (string sound)
    {
        Sounds s = Array.Find(soundsList, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }
}
