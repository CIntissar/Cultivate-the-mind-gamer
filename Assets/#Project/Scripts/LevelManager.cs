using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Transform treePainting;
    public float spritePositionY = 0f;
    public HatchesBehaviour hatchesBehaviour;
    public GameObject apple;
    public GameObject greenApple;
    public AppleBehaviour appleBehaviour;

    void Start()
    {
        appleBehaviour = apple.GetComponent<AppleBehaviour>();
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

        if(Input.GetMouseButtonDown(0))
        {
            if (hit2D.collider != null)
            {
                if (hit2D.collider.CompareTag("Apple"))
                {
                    if(appleBehaviour.spriteChanged)
                    {
                        SceneManager.LoadScene("EndScene");
                    }
                    else
                    {
                        GoToPainting();
                    }
                }
                
                if(hit2D.collider.CompareTag("Hatches"))
                {
                    hatchesBehaviour.SlideAndGrow();
                }
                if (hit2D.collider.CompareTag("GreenApple"))
                {
                    appleBehaviour.ChangeSprite();
                    greenApple.transform.DOScale(0, 0.4f).OnComplete(() => {
                        treePainting.DOMoveY(10.05152f,1);
                    });
                    //change the apple sprite
                    //rideaux
                }
            }
            else
            {
                Debug.Log("there's nothing here...");
            }
        }
    }
    void GoToPainting()
    {
        //temporary
        treePainting.DOMoveY(spritePositionY, 1).SetEase(Ease.OutBounce);
    }
}
