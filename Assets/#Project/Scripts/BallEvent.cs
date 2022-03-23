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
    public GameObject cursor;
    [SerializeField] MouseCursor mouseCursor;
    
    void Awake()
    {
        birdEvent = bird.GetComponent<BirdEvent>();
        animator = GetComponent<Animator>();
        bird = GameObject.FindGameObjectWithTag("Bird").GetComponent<SpriteRenderer>();
        mouseCursor = cursor.GetComponent<MouseCursor>();
        //add get component in children, returns array,
    }
    void Start()
    {
       spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }
    void OnMouseOver()
    {
        mouseCursor.ChngeToMagnifier();
    }
    void OnMouseExit()
    {
        mouseCursor.ChngeToDefault();
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
            yield return new WaitForSeconds(1.5f);
            isMoving = false;
            clickCount++;
        }
    }
    public IEnumerator OpenUpAndFly()
    {
        upperBall.DOMoveY(transform.position.y + 3f, 1f);
        yield return new WaitForSeconds(0.9f);
        bird.DOFade(1, 0.1f);
        foreach (SpriteRenderer rend in spriteRenderers)
        {
            rend.DOFade(0, 0.5f);
        }
        //animator.SetBool("fade", true);
        birdEvent.Fly();
    }
    
}
