using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EndSceneManager : MonoBehaviour
{
    [SerializeField] Transform leftCurtain;
    [SerializeField] Transform rightCurtain;
    [SerializeField] float endPosition;

    void Start()
    {
        OpenCurtains();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OpenCurtains()
    {
        FindObjectOfType<AudioManager>().Play("CurtainsClose");
        rightCurtain.DOMoveX(endPosition, 0.7f);
        leftCurtain.DOMoveX(-endPosition, 0.9f);
    }
}
