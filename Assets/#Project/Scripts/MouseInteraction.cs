using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MouseInteraction : MonoBehaviour
{
    public string ObjectTag = "Ball";
    public bool isMoving = false;
    public Vector3 currentRotation;
    public float clickCount = 0;
    //public float animationTime;
    void Start()
    {

    }
    void OnMouseOver()
    {
        //cursor change
        if(Input.GetMouseButtonDown(0))
        {
            switch(ObjectTag)
            {
                case "Ball":
                    //RollOver();
                    StartCoroutine(RollOver());
                    //isMoving = false;
                    break;
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
            clickCount++;
            yield return new WaitForSeconds(2f);
            isMoving = false;
        }
    }
    // public IEnumerator Wait()
    // {
    //     yield return new WaitForSeconds(.5f);
    // }
}
