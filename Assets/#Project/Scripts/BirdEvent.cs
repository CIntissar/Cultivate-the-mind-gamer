using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BirdEvent : MonoBehaviour
{
    Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Fly()
    {
        //transform.DOMove(new Vector3 (0f, 0f, 0), 0.5f);
        animator.SetBool("GoCenter", true);
        animator.SetBool("isFlying", true);
    }
}
