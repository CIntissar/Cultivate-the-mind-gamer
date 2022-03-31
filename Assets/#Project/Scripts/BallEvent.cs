using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BallEvent : MonoBehaviour
{
    [SerializeField] BirdEvent birdEvent;
    [SerializeField] SpriteRenderer bird;
    [HideInInspector] bool isMoving = false;
    Vector3 currentRotation;
    [HideInInspector] public float clickCount = 0;
    [SerializeField] Transform upperBall;
    [SerializeField] Animator animator;
    public SpriteRenderer[] spriteRenderers;
    
    void Awake()
    {
        birdEvent = bird.GetComponent<BirdEvent>();
        animator = GetComponent<Animator>();
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<SpriteRenderer>();
    }
    void Start()
    {
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
            bird.DOFade(1, 0.1f);
            foreach (SpriteRenderer rend in spriteRenderers)
            {
                rend.DOFade(0, 0.5f);
            }
            birdEvent.Fly();
        });
        yield return new WaitForSeconds(1.2f);
        gameObject.SetActive(false);
    }
}
