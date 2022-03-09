using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BalltoEye : MonoBehaviour
{
    //Function to make the pupil float after one click

    public float clickCount = 0;
    public MovingCamera movingCamera;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(movingCamera.ballCenter == true && this.GetComponent<Collider>().CompareTag("Pupil"))
            {
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

    void FloatingBall()
    {
        transform.DOMoveY(transform.position.y + 4.45f, 2f);
    }

    void Blink()
    {
        //having a transition (fading in/out) to make appear the eyes 
        // animation blink every 5 sec?
        
    }
    
}
