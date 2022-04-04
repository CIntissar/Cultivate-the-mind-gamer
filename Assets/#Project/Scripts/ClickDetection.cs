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
    [SerializeField] FakeBirdBehaviour fakeBirdBehaviour;

    void Awake()
    {
        birdEvent = bird.GetComponent<BirdEvent>();
        ballEvent = ball.GetComponent<BallEvent>();
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
                if(hit2D.collider.CompareTag("Fake"))
                {
                    fakeBirdBehaviour.DestroyBird();
                }
            }
            else
            {
                Debug.Log("there's nothing here...");
            }
        }
    }
}
