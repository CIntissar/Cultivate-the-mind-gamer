using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ClickChange : MonoBehaviour
{
    
    public bool pupilOn = false;
    [HideInInspector] public Tween myTween;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if (hit2D.collider != null)
            {
                if(hit2D.collider.CompareTag("Cloud_1"))
                {
                    Debug.Log("Ceci n'est pas un nuage");
                    //Find a way to differentiate each one
                    myTween = transform.DOPunchScale(new Vector3 (0.85f,0.85f,0), 0.5f, 2, 2f).OnComplete(() => {
                    transform.DOScale(0, 0.25f);
                    });

                }
            }
            pupilOn = true;
        }
    }
}
