using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HatchesBehaviour : MonoBehaviour
{
    //public bool isSliding = false;
    public GameObject[] hatches = new GameObject[3];
    public Transform apple;
    public RaycastHit2D hit2D;
    //public Transform firstSprite;
    //public Transform secondSprite;
    //public bool hatchesClicked = false;
    public List<Transform> sprites = new List<Transform>();
    public int index = 0;
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
        for (int j = 0; j < hatches.Length; j++)
        {
            if(hit2D.collider.gameObject == hatches[j].gameObject)
            {
                sprites[index].position = hatches[j].transform.position;
                hatches[j].transform.DOMoveX(4,1);
                index++;
            }
        }
            //hatchesClicked = true;
            //apple.DOScale(new Vector2(1f,1f), 0.1f);
            //isSliding = false;
            //boucle for des sprites avant celle des portes
    }
}
