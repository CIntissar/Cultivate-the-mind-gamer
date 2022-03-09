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
    public float limitTravel = 15f;

    public bool ballCenter = false;

    void Start()
    {
        m_MainCamera = Camera.main;
        cameraTransform = Camera.main.gameObject.transform;

        Button left = leftButton.GetComponent<Button>();
        Button right = rightButton.GetComponent<Button>();

		left.onClick.AddListener(MoveLeft);
        right.onClick.AddListener(MoveRight);
    }

    void Update()
    {
        if(cameraTransform.position.x == -limitTravel)
        {
            ballCenter = true;
        }
        else
        {
            ballCenter = false;
        }
    }

    void MoveLeft()
    {
        if(ballCenter == false)
        {
            Debug.Log("You're going to the left"); 

            if(cameraTransform.position.x <= -limitTravel)
            {
                cameraTransform.Translate(0,0,0);
                Debug.Log("Reserved to staff");
            }
            else
            {
                cameraTransform.Translate(-travel,0,0);
            }
        }
        else
        {
            cameraTransform.Translate(0,0,0);
        }

    }

    void MoveRight()
    {
        if(ballCenter == false)
        {
            Debug.Log("You're going to the right");
            
            if(cameraTransform.position.x >= limitTravel)
            {
                cameraTransform.Translate(0,0,0);
                Debug.Log("Reserved to staff");
            }
            else
            {
                cameraTransform.Translate(travel,0,0);
            }
        }
        else
        {
            cameraTransform.Translate(0,0,0);
        }
    }
}
