using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingCamera : MonoBehaviour
{
    Camera m_MainCamera;
    Transform cameraTransform;
    public Button leftButton;
    public Button rightButton;
    public float travel = 5.0f;

    void Start()
    {
        m_MainCamera = Camera.main;
        cameraTransform = Camera.main.gameObject.transform;

        Button left = leftButton.GetComponent<Button>();
        Button right = rightButton.GetComponent<Button>();

		left.onClick.AddListener(MoveLeft);
        right.onClick.AddListener(MoveRight);
    }

    void MoveLeft()
    {
        
        Debug.Log("You're going to the left"); 
        cameraTransform.Translate(-travel,0,0);
        
    }

    void MoveRight()
    {
        Debug.Log("You're going to the right");
        cameraTransform.Translate(travel,0,0);

    }
}
