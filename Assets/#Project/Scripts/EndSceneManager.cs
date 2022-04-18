using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;
using DG.Tweening;

public class EndSceneManager : MonoBehaviour
{
    [SerializeField] Transform _leftCurtain;
    [SerializeField] Transform _rightCurtain;
    [SerializeField] float _endPosition;
    AudioManager _mySound;

    void Awake()
    {
        _mySound = FindObjectOfType<AudioManager>();
    }
    void Start()
    {
        _mySound.StopPlaying("MountainAmbiance");
        OpenCurtains();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Menu");
        }
    }
    void OpenCurtains()
    {
        _mySound.Play("CurtainsClose");
        _rightCurtain.DOMoveX(_endPosition, 0.9f);
        _leftCurtain.DOMoveX(-_endPosition, 1.1f);
    }

    
}
