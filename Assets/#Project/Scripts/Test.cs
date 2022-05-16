using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine;

public class Test : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    //Script for the clic detection and we can manage all the fonctions!
    public UnityEvent onClick;
    // public UnityEvent onClickTwice;
    // public UnityEvent onClickThrice;
    
    public void OnPointerDown( PointerEventData eventData )
    {

    }
    public void OnPointerUp( PointerEventData eventData )
    {

    }
    public void OnPointerClick( PointerEventData eventData )
    {
        onClick?.Invoke();
    }
}
