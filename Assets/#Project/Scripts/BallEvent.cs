using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BallEvent : MonoBehaviour
{
    public BirdEvent birdEvent;
    public Transform bird;
    public bool isMoving = false;
    public Vector3 currentRotation;
    public float clickCount = 0;
    public Transform upperBall;

    public float counter = 0;
    //Animator animator;
    
    
    void Awake()
    {
        //bird = GetComponentInChildren<BirdEvent>();
        birdEvent = bird.GetComponent<BirdEvent>();
        //animator = GetComponent<Animator>();
    }
    void Start()
    {

    }

    void Update()
    {
        
    }
    void OnMouseOver()
    {

    }
    public IEnumerator RollOver()
    {
        if(isMoving == false && clickCount < 3)
        {
            isMoving = true;
            currentRotation = transform.eulerAngles;
            transform.DOMoveX(transform.position.x + 4f, 2f);
            transform.DORotate(new Vector3 (0, 0, currentRotation.z - 120f), 2f);
            transform.DOScale(new Vector3(transform.localScale.x + 0.4f, transform.localScale.y + 0.4f, 0), 2f);
            //bird.DOMove(new Vector3 (10f, 10f, 0), 1f);
            yield return new WaitForSeconds(1.5f);
            isMoving = false;
            clickCount++;
        }
    }
    public IEnumerator OpenUpAndFly()
    {
        upperBall.DOMoveY(transform.position.y + 3f, 1f);
        yield return new WaitForSeconds(0.9f);
        birdEvent.Fly();
        //bird.DOMove(new Vector3 (10f, 10f, 0), 1f);
        //bird.animator.SetBool("isFlying", true);
        //StartCoroutine(birdEvent.Fly());
    }
    
}
