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
        if(balltoEye.blinkTransition == true)
        {
            animator.SetBool("isBlinking", true);
        }

        if(balltoEye.pokingTransition == true)
        {
            animator.SetBool("pokingTransition", true);
        }

        // if(balltoEye.pokingCount == 1)
        // {
        //     animator.SetInteger("poking", 1);
        // }
        // else if(balltoEye.pokingCount == 2)
        // {
        //     animator.SetInteger("poking", 2);
        // }
        // else if(balltoEye.pokingCount == 3)
        // {
        //     animator.SetInteger("poking", 3);
        // }
        // else if(balltoEye.pokingCount == 4)
        // {
        //     animator.SetInteger("poking", 4);
        // }
    }
}
