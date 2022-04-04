using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour
{
    public Animator animator;
    public BalltoEye balltoEye;
    
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(balltoEye.arrowAway == true)
        {
            animator.SetBool("arrowGone", true);
        }

        if(balltoEye.blinkTransition == true)
        {
            animator.SetBool("isBlinking", true);
        }

        if(balltoEye.pokingTransition == true)
        {
            animator.SetBool("pokingTransition", true);
        }

        else if(balltoEye.poke1 == true)
        {
            animator.SetBool("pokingTransition", true);
        }
        else if(balltoEye.poke2 == true)
        {
            animator.SetBool("pokingTransition", true);
        }
        else if(balltoEye.poke3 == true)
        {
            animator.SetBool("pokingTransition", true);
        }
    }
}
