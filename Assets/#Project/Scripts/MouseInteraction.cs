using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MouseInteraction : MonoBehaviour
{
    public string ObjectTag = "Ball";

    [HideInInspector]
    public bool isMoving = false;

    [HideInInspector]
    public Vector3 currentRotation;

    [HideInInspector]
    public float clickCount = 0;
    public Transform upperBall;
    public Transform bird;
    public float limitX;
    public float limitY;
    void Start()
    {

    }
    void Update()
    {
        limitX = Random.Range(-4f, 4f);
        limitY = Random.Range(-7f, 7f);
    }
    void OnMouseOver()
    {
        //cursor change
        if(Input.GetMouseButtonDown(0))
        {
            switch(ObjectTag)
            {
                case "Ball":
                    StartCoroutine(RollOver());
                    break;
            }
            if (clickCount == 3)
            {
                StartCoroutine(OpenUp());
            }
        }
    }
    void OnMouseExit()
    {
        //Debug.Log("not hovering...");
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
            yield return new WaitForSeconds(2f);
            isMoving = false;
            clickCount++;
        }
    }
    public IEnumerator OpenUp() //public IEnumerator OpenUp()
    {
        upperBall.DOMoveY(transform.position.y + 3f, 1f);
        yield return new WaitForSeconds(1f);
        bird.DOMove(new Vector3 (limitX, limitY, 0), 1f).SetLoops(-1, LoopType.Restart);
        //faire une boucle ?
        //limite = -7x, 4y, 7x, -4y
    }
}
