using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ClickDetection : MonoBehaviour
{
    public BallEvent ballEvent;
    public GameObject ball;
    public BirdEvent birdEvent;
    public GameObject bird;

    void Awake()
    {
        ballEvent = ball.GetComponent<BallEvent>();
        birdEvent = bird.GetComponent<BirdEvent>();
        //birdAnimator = GameObject.FindGameObjectWithTag("Bird").GetComponent<Animator>();
    }

    void Start()
    {

    }
    void Update() //put this code in another function
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //using raycasts
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);
        
        if(Input.GetMouseButtonDown(0)) //if left click is pressed
        {
            if (hit2D.collider != null) //if the ray hits something
            {
                if (hit2D.collider.CompareTag("Ball")) //if that something is the ball
                {
                    StartCoroutine(ballEvent.RollOver()); //the ball rolls
                    if(ballEvent.clickCount >= 3) //if it rolled 3 times
                    {
                        StartCoroutine(ballEvent.OpenUpAndFly()); //balls opens up and bird starts flying
                    }
                }
                if(hit2D.collider.CompareTag("Bird"))
                {
                    birdEvent.StopAndExpand(); //bird stops flying and expands
                }
            }
            else
            {
                Debug.Log("there's nothing here...");
            }
        }
    }
}
