using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MovingCamera : MonoBehaviour
{
    Camera m_MainCamera;
    Transform cameraTransform;
    public Button leftButton;
    public Button rightButton;
    public float travel = 10.0f;
    public float limitTravel = 20f;
    public bool ballCenter = false;
    public ClickChange clickChange;
    public GameObject pupil;

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
        if(clickChange.pupilOn == true)
        {
            pupil.transform.DOMoveY(-0.68f,0.2f).SetEase(Ease.InBounce);
            //DOShakePosition(float duration, float/Vector3 strength, int vibrato, float randomness, bool snapping, bool fadeOut)?
            // A ESSAYER!!!!

            pupil.SetActive(true);
            //-> faire en sorte qu'il remonte en un coup de la mer!!! 
        }

        if(cameraTransform.position.x == -limitTravel && clickChange.oceanUp)
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
                leftButton.interactable = false;
            }
            else
            {
                Debug.Log("BABY COME BACK");
                cameraTransform.Translate(-travel,0,0);
                rightButton.interactable = true;    
            }
        }
        else
        {
            cameraTransform.Translate(0,0,0);
            // leftButton.enabled = false;
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
                rightButton.interactable = false;
            }
            else
            {
                cameraTransform.Translate(travel,0,0);
                leftButton.interactable = true;
            }
        }
        else
        {
            cameraTransform.Translate(0,0,0);
            // rightButton.enabled = false;
        }
    }
    
}
