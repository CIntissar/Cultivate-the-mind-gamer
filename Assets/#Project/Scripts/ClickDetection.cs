using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ClickDetection : MonoBehaviour
{
    public BallEvent ballEvent;
    public GameObject ball;
    public Animator canvaAnimator;
    //public Animator birdAnimator;
    //public GameObject birdPrefab;
    //public Transform birdOrigin;
    //public bool birdAppeared = false;
    //public Transform birdPrefab;
    void Awake()
    {
        ballEvent = ball.GetComponent<BallEvent>();
        canvaAnimator = GameObject.FindGameObjectWithTag("FadeIn").GetComponent<Animator>();
        //birdAnimator = GameObject.FindGameObjectWithTag("Bird").GetComponent<Animator>();
    }
    void Start()
    {
        //GameObject birdClone = Instantiate(birdPrefab, birdOrigin.position, birdOrigin.rotation);
        //birdClone.transform.DOMoveY(10f, 1f);
        //birdAnimator.SetBool("isFlying", true);
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
                        FadeIn(); //retirer le fadeIn
                        StartCoroutine(ballEvent.OpenUpAndFly());
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
    public void FadeIn()
    {
        canvaAnimator.SetBool("GetDark", true); //??change fade in duration
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
