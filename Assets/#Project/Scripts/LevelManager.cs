using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //[SerializeField] Transform treePainting; //delete this
    [SerializeField] HatchesBehaviour hatchesBehaviour;
    public GameObject apple; //shadow apple
    [SerializeField] GameObject greenApple;
    AppleBehaviour appleBehaviour;

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
                    hatchesBehaviour.Slide();
                }
                if (hit2D.collider.CompareTag("GreenApple"))
                {
                    appleBehaviour.ChangeSprite();
                    StartCoroutine(hatchesBehaviour.ScaleDown());
                    //rideaux
                }
            }
            else
            {
                Debug.Log("there's nothing here...");
            }
        }
    }
    void GoToPainting() //put this in hatchets behaviour
    {
        hatchesBehaviour.DropDown();
    }
}
