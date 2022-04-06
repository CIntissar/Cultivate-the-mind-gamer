using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HatchesBehaviour : MonoBehaviour
{
    // [SerializeField] float spritePositionY = -0.05f; //put this in hatches behaviour + sprite position at -0.05f
    // [SerializeField] Ease easeType = Ease.OutBounce;
    // [SerializeField] GameObject[] hatches = new GameObject[3];
    // RaycastHit2D hit2D;
    // Ray ray;
    // [SerializeField] List<Transform> sprites = new List<Transform>();
    public bool canMove = true;
    //float xPosition = 4f;
    void Start()
    {
       
    }
    
    void Update()
    {
        // ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // hit2D = Physics2D.GetRayIntersection(ray);
    }

    // public void DropDown()
    // {
    //     transform.DOMoveY(spritePositionY, 1).SetEase(easeType);
    // }
    // public void Slide()
    // {
    //     for (int i = 0; i < hatches.Length; i++) //for each door
    //     {
    //         if(hit2D.collider.gameObject == hatches[i].gameObject && canMove)
    //         {
    //             sprites[i].position = hatches[i].transform.position;
    //             hatches[i].transform.DOMoveX(xPosition,1).OnComplete(() => {
    //                 if(hatches[i].transform.position.x == xPosition)
    //                 {
    //                     canMove = false;
    //                 }
    //             });
    //         }
    //     }
    // }
    // public IEnumerator ScaleDown()
    // {
    //     for (int i = 0; i < sprites.Count; i++)
    //     {
    //         sprites[i].transform.DOScale(Vector3.zero, 0.4f);
    //     }
    //     yield return new WaitForSeconds(0.8f);
    //     transform.DOMoveY(10.05152f,1);
    // }
}
