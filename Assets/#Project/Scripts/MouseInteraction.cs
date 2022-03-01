using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MouseInteraction : MonoBehaviour
{
    public string ObjectTag = "Ball";
    public bool isMoving = false;
    void OnMouseOver()
    {
        //cursor change
        if(Input.GetMouseButtonDown(0))
        {
            switch(ObjectTag)
            {
                case "Ball":
                    RollOver();
                    isMoving = false;
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
            isMoving = true;
            transform.DOMoveX(transform.position.x + 4, 2);
        }
    }
}
