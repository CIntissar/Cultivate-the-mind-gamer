using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ClickDetection : MonoBehaviour
{
    BallEvent ballEvent;
    //BirdEvent birdEvent;
    //[SerializeField] GameObject bird;
    [SerializeField] GameObject ball;
    //public string ObjectTag = "Ball";
    //public Transform upperBall;
    //public Transform bird;
    //public Collider2D collider;
    void Awake()
    {
        ballEvent = ball.GetComponent<BallEvent>();
        //birdEvent = bird.GetComponent<BirdEvent>();
    }
    void Start()
    {

    }
    void Update() //put this code in another function
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if (hit2D.collider != null)
            {
                if (hit2D.collider.CompareTag("Ball"))
                {
                    StartCoroutine(ballEvent.RollOver());
                    //Debug.Log("Hit 2D Collider" + hit2D.collider.tag);
                    if(ballEvent.clickCount == 3)
                    {
                        StartCoroutine(ballEvent.OpenUp());
                    }
                }
            }
            else
            {
                Debug.Log("there's nothing here...");
            }
        }
    }
    void OnMouseOver()
    {

    }
    // void OnMouseExit()
    // {

    // }
    // public void Fly()
    // {
    //     bird.DOMove(new Vector3 (Random.Range(0, 14), Random.Range(1, 6.5f), 0), 1f);
    // }
    //limite = x -> 0, 14   y -> 6.5, 1
    // milieu = x -> 7    y -> 3
}
