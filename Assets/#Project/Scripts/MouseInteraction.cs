using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MouseInteraction : MonoBehaviour
{
    public string ObjectTag = "Ball";
    public bool isMoving = false;
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
                    RollOver();
                    //isMoving = false;
                    break;
            }
        }
    }
    void OnMouseExit()
    {
        //Debug.Log("not hovering...");
    }
    public void RollOver()
    {
        if(isMoving==false)
        {
            //isMoving = true;
            transform.DOMoveX(transform.position.x + 4f, 2f);
            Debug.Log("rotating...");
            //transform.DORotateQuaternion(, 2f);
            transform.DOScale(new Vector3(transform.localScale.x + 0.5f, transform.localScale.y + 0.5f, 0), 2);
        }
    }
}
