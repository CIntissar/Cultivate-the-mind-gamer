using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMenu : MonoBehaviour
{
    public Animator animator;
    public MenuClick menuClick;

    void Start()
    {
        // THOMAS: Caching of objects can/should be done in Awake
        // Look at it like this: in Awake you initialize everything that is related to your own class
        // in Start everything that is related to other classes.
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {   
        // THOMAS: put this is a seperate function and call from MenuClick
        // remove the if(..) check
        // this class doesn't need to know about MenuClick
        if(menuClick.appleOn)
        {
            animator.SetBool("appleFalling",true);
        }
    }
}
