using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BallEvent : MonoBehaviour
{
    [SerializeField] BirdEvent birdEvent;
    [SerializeField] SpriteRenderer bird;
    [SerializeField] FakeBirdBehaviour fakeBirdBehaviour;
    [HideInInspector] bool isMoving = false;
    Vector3 currentRotation;
    [HideInInspector] public float clickCount = 0;
    [SerializeField] Transform upperBall;
    public SpriteRenderer[] spriteRenderers;
    void Start()
    {
        birdEvent = bird.GetComponent<BirdEvent>();
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<SpriteRenderer>();
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }
    void Update()
    {
        
    }
    public IEnumerator RollOver()
    {
        if(isMoving == false && clickCount < 3)
        {
            isMoving = true;
            currentRotation = transform.eulerAngles;
            transform.DOMoveX(transform.position.x + 4f, 1.5f);
            transform.DORotate(new Vector3 (0, 0, currentRotation.z - 120f), 1.5f);
            transform.DOScale(new Vector3(transform.localScale.x + 0.4f, transform.localScale.y + 0.4f, 0), 1.5f);
            yield return new WaitForSeconds(1.5f);
            isMoving = false;
            clickCount++;

            if(clickCount == 3) //if it rolled 3 times
            {
                StartCoroutine(OpenUpAndFly()); //balls opens up and bird starts flying
            }
        }
        
    }
    public IEnumerator OpenUpAndFly()
    {
        upperBall.DOMoveY(transform.position.y + 3f, 0.9f).OnComplete(() => {
            bird.DOFade(1, 0.1f); //foreach (Spriterenderer item in birdsSprite) --> do fade
            fakeBirdBehaviour.FadeIn(); // delete this
            foreach (SpriteRenderer rend in spriteRenderers)
            {
                rend.DOFade(0, 0.5f);
            }
            birdEvent.Fly(); //call the other function
            fakeBirdBehaviour.StartFlying(); //dlete this
        });
        yield return new WaitForSeconds(1.2f);
        gameObject.SetActive(false);
        //1. maybe switch brid fade and ball fade ?
    }
}
