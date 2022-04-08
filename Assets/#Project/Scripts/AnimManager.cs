using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour
{
    public Animator animator;
    public BalltoEye balltoEye;
    public ClickChange clickChange;
    
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // THOMAS: move this out of the Update loop, and call them from other classes 
        // THOMAS: these are actually more animation 'triggers' than booleans as well.
        if(balltoEye.arrowAway == true)
        {
            animator.SetBool("arrowGone", true);
        }

        if(balltoEye.blinkTransition == true)
        {
            animator.SetBool("isBlinking", true);
        }

        if(clickChange.pokingTransition == true)
        {
            animator.SetBool("pokingTransition", true);
        }

        if(clickChange.poke1 == true)
        {
            animator.SetBool("poke1", true);
        }
        if(clickChange.poke2 == true)
        {
            animator.SetBool("poke2", true);
        }
        if(clickChange.poke3 == true)
        {
            animator.SetBool("poke3", true);
        }
    }
}
