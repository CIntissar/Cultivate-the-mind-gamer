using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ClickDetection : MonoBehaviour
{
    [SerializeField] BallEvent ballEvent;
    public GameObject ball;
    [SerializeField] BirdEvent birdEvent;
    public GameObject bird;

    void Awake()
    {
        ballEvent = ball.GetComponent<BallEvent>();
        birdEvent = bird.GetComponent<BirdEvent>();
    }

    void Start()
    {

    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);
        
        if(Input.GetMouseButtonDown(0))
        {
            if (hit2D.collider != null) //if the ray hits something
            {
                if (hit2D.collider.CompareTag("Ball")) //if that something is the ball
                {
                    StartCoroutine(ballEvent.RollOver()); //the ball rolls
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
