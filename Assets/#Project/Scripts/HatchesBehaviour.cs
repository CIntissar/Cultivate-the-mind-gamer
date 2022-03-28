using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HatchesBehaviour : MonoBehaviour
{
    //public Transform hatches;
    public bool isSliding = false;
    public Transform apple;
    public Transform[] hatches = new Transform[3];
    void Start()
    {
       //hatches = GetComponentsInChildren<Transform>();
    }
    
    void Update()
    {
        
    }

    public void SlideAndGrow()
    {
        apple.DOScale(new Vector2(1f,1f), 0.2f);
        foreach (var item in hatches)
        {
            item.DOMoveX(4,1); //add on complete
        }
        isSliding = false;
    }
}
