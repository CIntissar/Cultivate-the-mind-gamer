using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HatchesBehaviour : MonoBehaviour
{
    //public Transform hatches;
    //public bool isSliding = false;
    public GameObject[] hatches = new GameObject[3];
    public Transform apple;
    public RaycastHit2D hit2D;
    
    //public bool hatchesClicked = false;
    void Start()
    {
       //hatches = GetComponentsInChildren<Transform>();
    }
    
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hit2D = Physics2D.GetRayIntersection(ray);
    }

    public void SlideAndGrow()
    {
        for (int i = 0; i < hatches.Length; i++)
        {
            if(hit2D.collider.gameObject == hatches[i].gameObject)
            {
                hatches[i].transform.DOMoveX(4,1);
            }
        }
        //hatchesClicked = true;
        apple.DOScale(new Vector2(1f,1f), 0.2f);
        //isSliding = false;
    }
}
