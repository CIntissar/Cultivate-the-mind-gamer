using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MouseInteraction : MonoBehaviour
{
    void OnMouseOver()
    {
        //cursor change
        //Debug.Log("hovering !");
    }
    void OnMouseExit()
    {
        //Debug.Log("not hovering...");
    }
    void OnClick()
    {
        if(gameObject.CompareTag("Ball"))
        {
            //do something
            Debug.Log("Clicked");
        }
    }
    void RollOver()
    {

    }
}
