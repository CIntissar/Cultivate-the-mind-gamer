using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ClickDetection : MonoBehaviour
{
    [HideInInspector] public List<GameObject> birds = new List<GameObject>();
    [SerializeField] int nbrOfBirds = 5;
    public float clickedOnce = 0;
    [SerializeField] AudioManager _mySound;
    bool triggerFunction = false;
    void Start()
    {
        _mySound = FindObjectOfType<AudioManager>();
        _mySound.Play("ForestAmbiance");
    }
    void Update()
    {
        if (clickedOnce >= nbrOfBirds && triggerFunction == false)
        {
            triggerFunction = true;
            KillAllTweens();
            birds[nbrOfBirds - 1].GetComponent<BirdBehaviour>().StopAndExpand();

        }
    }
    void AllBirdsSelected()
    {

    }
    void KillAllTweens()
    {
        for (int i = 0; i < birds.Count; i++)
        {
            birds[i].GetComponent<BirdBehaviour>().myTween.Kill();
        }
    }
}
