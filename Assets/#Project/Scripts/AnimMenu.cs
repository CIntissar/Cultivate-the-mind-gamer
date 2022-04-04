using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMenu : MonoBehaviour
{
    public Animator animator;
    public MenuClick menuClick;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {   
        if(menuClick.touch < 3)
        {
            animator.SetTrigger("activate");
        }
        

        if(menuClick.appleOn)
        {
            animator.SetBool("appleFalling",true);
        }
    }
}
