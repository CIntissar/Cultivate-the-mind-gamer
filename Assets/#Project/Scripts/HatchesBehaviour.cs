using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HatchesBehaviour : MonoBehaviour
{
    //public Transform hatches;
    public bool isSliding = false;
    public Transform apple;
    void Start()
    {
       //hatches = GetComponentsInChildren<HatchesBehaviour>();
    }
    
    void Update()
    {
        
    }
    public void SlideAndGrow()
    {
        isSliding = true;
        apple.DOScale(new Vector2(0.18f,0.18f), 0.2f);
        transform.DOMoveX(4,1); //add on complete
        isSliding = false;
    }
}
