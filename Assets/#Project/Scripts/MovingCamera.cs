using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingCamera : MonoBehaviour
{
    Camera m_MainCamera;
    public Button leftButton;
    public Button rightButton;

    //private bool isLeft;
    void Start()
    {
        m_MainCamera = Camera.main;
        Button left = leftButton.GetComponent<Button>();
        Button right = rightButton.GetComponent<Button>();

		left.onClick.AddListener(MoveCamera/*(true)*/);
        right.onClick.AddListener(MoveCamera/*(false)*/);
    }

    void Update()
    {
        
    }

    void MoveCamera(/*bool isLeft*/)
    {
        Debug.Log("You're moving");
        // if(isLeft == true)
        // {
        //     Debug.Log("You're going to the left");
        // }
        // else if(isLeft == false)
        // {
        //     Debug.Log("You're going to the right");
        // }
        
    }
}
