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
    public SpriteRenderer[] birdSprites;
    public float clickedOnce = 0;
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
                for (int i = 0; i < birds.Count; i++)
                {
                    if(hit2D.collider.gameObject == birds[i].gameObject && birds[i].GetComponent<BirdEvent>().canBeClicked)
                    {
                        //sound : poof
                        clickedOnce += 1;
                        birds[i].GetComponent<BirdEvent>().canBeClicked = false;
                        birdSprites[i].DOColor(new Color (0.3f, 0.4f, 0.6f, 1f), 0.2f);
                        print(clickedOnce);
                        if(clickedOnce >= birds.Count)
                        {
                            KillAllTweens();
                            birds[i].GetComponent<BirdEvent>().StopAndExpand();
                        }
                    }
                }
            }
            else
            {
                Debug.Log("there's nothing here...");
            }
        }
    }
    void KillAllTweens()
    {
        for (int i = 0; i < birds.Count; i++)
        {
            birds[i].GetComponent<BirdEvent>().myTween.Kill();
        }
    }
}
