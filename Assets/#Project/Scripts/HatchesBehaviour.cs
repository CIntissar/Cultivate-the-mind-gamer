using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HatchesBehaviour : MonoBehaviour
{
    [SerializeField] float spritePositionY = -0.05f; //put this in hatches behaviour + sprite position at -0.05f
    [SerializeField] Ease easeType = Ease.OutBounce;
    public GameObject[] hatches = new GameObject[3];
    RaycastHit2D hit2D;
    Ray ray;
    public List<Transform> sprites = new List<Transform>();
    int index = 0;
    public bool canMove = true;
    float xPosition = 4f;
    void Start()
    {
       
    }
    
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hit2D = Physics2D.GetRayIntersection(ray);
    }

    public void DropDown()
    {
        transform.DOMoveY(spritePositionY, 1).SetEase(easeType);
    }
    public void Slide()
    {
        for (int j = 0; j < hatches.Length; j++)
        {
            if(hit2D.collider.gameObject == hatches[j].gameObject && canMove)
            {
                sprites[index].position = hatches[j].transform.position;
                hatches[j].transform.DOMoveX(xPosition,1).OnComplete(() => {
                    if(hatches[j].transform.position.x == xPosition)
                    {
                        canMove = false;
                    }
                });
                index++;
            }
            else
            {
                print("...");
            }
        }
    }
    public IEnumerator ScaleDown()
    {
        for (int i = 0; i < sprites.Count; i++)
        {
            sprites[i].transform.DOScale(Vector3.zero, 0.4f);
        }
        yield return new WaitForSeconds(0.8f);
        transform.DOMoveY(10.05152f,1);
    }
}
