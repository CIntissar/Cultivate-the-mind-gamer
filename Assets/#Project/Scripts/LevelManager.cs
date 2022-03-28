using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelManager : MonoBehaviour
{
    public Transform treePainting;
    public float spritePositionY = 0f;
    //public GameObject[] hatches;
    public HatchesBehaviour hatchesBehaviour;
    public GameObject apple;
    public GameObject greenApple;
    public bool hatchesClicked;
    //public AppleBehaviour appleBehaviour;
    //public GameObject[] hatches;
    // public GameObject hatch0;
    // public GameObject hatch1;
    // public GameObject hatch2;

    void Start()
    {
        //appleBehaviour = apple.GetComponent<AppleBehaviour>();
        // hatch0 = GameObject.FindGameObjectWithTag("Hatches");
        // hatch1 = GameObject.FindGameObjectWithTag("Hatches");
        // hatch2 = GameObject.FindGameObjectWithTag("Hatches");

        // hatchesBehaviour = hatch0.GetComponent<HatchesBehaviour>();
        // hatchesBehaviour = hatch1.GetComponent<HatchesBehaviour>();
        // hatchesBehaviour = hatch2.GetComponent<HatchesBehaviour>();

        // foreach (var item in hatches)
        // {
        //     hatchesBehaviour = item.GetComponent<HatchesBehaviour>();
        // }

        // for (int i = 0; i < hatches.Length; i++)
        // {
        //     hatchesBehaviour[i] = hatches[i].GetComponent<HatchesBehaviour>();
        // }

        // hatchesBehaviour[0] = hatches[0].GetComponent<HatchesBehaviour>();
        // hatchesBehaviour[1] = hatches[1].GetComponent<HatchesBehaviour>();
        // hatchesBehaviour[2] = hatches[2].GetComponent<HatchesBehaviour>();

        //!!!!!Simplement drag'n droper l'object avec le script dans l'inspecteur

    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //using raycasts
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

        if(Input.GetMouseButtonDown(0))
        {
            if (hit2D.collider != null)
            {
                if (hit2D.collider.CompareTag("Apple"))
                {
                    //print("hey apple !");
                    GoToPainting();
                }

                // for (int i = 0; i < hatches.Length; i++)
                // {
                //     if(hit2D.collider.CompareTag("Hatches"))
                //     {
                //         hatchesBehaviour[i].SlideAndGrow();
                //     }
                // }
                if(hit2D.collider.CompareTag("Hatches"))
                {
                    hatchesBehaviour.SlideAndGrow();
                }
                if (hit2D.collider.CompareTag("GreenApple"))
                {
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
