using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HatchesBehaviour : MonoBehaviour
{
    public GameObject[] hatches = new GameObject[3];
    public Transform apple;
    RaycastHit2D hit2D;
    public List<Transform> sprites = new List<Transform>();
    int index = 0;
    void Start()
    {
       
    }
    
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hit2D = Physics2D.GetRayIntersection(ray);
    }

    public void SlideAndGrow()
    {
        for (int j = 0; j < hatches.Length; j++)
        {
            if(hit2D.collider.gameObject == hatches[j].gameObject)
            {
                sprites[index].position = hatches[j].transform.position;
                hatches[j].transform.DOMoveX(4,1);
                index++;
            }
        }
    }
}
