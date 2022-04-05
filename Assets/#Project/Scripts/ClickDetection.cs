using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ClickDetection : MonoBehaviour
{
    [SerializeField] BallEvent ballEvent;
    public GameObject ball;
    public List<GameObject> birds = new List<GameObject>();
    void Start()
    {
        ballEvent = ball.GetComponent<BallEvent>();
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
                foreach (GameObject item in birds)
                {
                    if(hit2D.collider.CompareTag("Bird"))
                    {
                        item.GetComponent<BirdEvent>().StopAndExpand(); //bird stops flying and expands 
                    }
                    else if (hit2D.collider.CompareTag("Fake"))
                    {
                        Destroy(item);
                    }
                }
            }
            else
            {
                Debug.Log("there's nothing here...");
            }
        }
    }
}
