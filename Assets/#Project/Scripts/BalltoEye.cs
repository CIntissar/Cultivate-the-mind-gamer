using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BalltoEye : MonoBehaviour
{
    //Function to make the pupil float after one click

    public Animator animator;
    public float clickCount = 0;
    public MovingCamera movingCamera;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if (hit2D.collider != null)
            {
                if (movingCamera.ballCenter == true && hit2D.collider.CompareTag("Pupil"))
                {
                    Debug.Log("DON'T TOUCH ME!!!");

                    clickCount++;

                    if(clickCount == 1)
                    {
                        FloatingBall();
                    }
                    else if(clickCount == 2)
                    {
                        Blink();
                    }
                }
            }
        }
    }

    void FloatingBall()
    {
        transform.DOMoveY(transform.position.y + 5.50f, 2f);
    }

    void Blink()
    {
        //having a transition (fading in/out) to make appear the eyes 
        // animation blink every 5 sec?
        
    }
    
}
