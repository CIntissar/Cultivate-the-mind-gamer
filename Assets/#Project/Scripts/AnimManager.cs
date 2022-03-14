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
    }
}
