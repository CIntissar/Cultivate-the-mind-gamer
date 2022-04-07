using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 
using UnityEngine;
using DG.Tweening;

public class EndSceneManager : MonoBehaviour
{
    [SerializeField] Transform leftCurtain;
    [SerializeField] Transform rightCurtain;
    [SerializeField] float endPosition;

    void Start()
    {
        FindObjectOfType<AudioManager>().StopPlaying("MountainAmbiance");
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
        FindObjectOfType<AudioManager>().Play("CurtainsClose");
        rightCurtain.DOMoveX(endPosition, 0.9f);
        leftCurtain.DOMoveX(-endPosition, 1.1f);
    }

    
}
