using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MouseInteraction : MonoBehaviour
{
    string ballTag = "Ball";
    void OnMouseOver()
    {
        //cursor change
        if(Input.GetMouseButtonDown(0))
        {
            switch(ballTag)
            {
                case "Ball":
                    RollOver();
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
        transform.DOMoveX(transform.position.x + 5, 3);
    }
}
