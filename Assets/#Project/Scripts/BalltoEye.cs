using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BalltoEye : MonoBehaviour
{
    //Function to make the pupil float after one click
    
    //make it change as an apple? -> having other paints reference?
    public float clickCount = 0;


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
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

    void FloatingBall()
    {
        transform.DOMoveY(transform.position.y + 5.0f, 2f);
    }

    void Blink()
    {
        //having a transition (fading in/out) to make appear the eyes 
        // animation blink every 5 sec?
        
    }
    
}
