using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuClick : MonoBehaviour
{
    public int touch = 0;
    public int counter = 0;
    public int limitTouch = 3;
    public GameObject man;
    public GameObject hat;
    public GameObject apple;
    public GameObject frame;
    public GameObject frame2;
    public GameObject frame3;
    public bool appleOn = false;
    [HideInInspector] public Tween myTween;


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if (hit2D.collider != null)
            {
                                
                if(hit2D.collider.CompareTag("Lion"))
                {
                    if(counter == 0)
                    {
                        //animation -> Lion Appear!
                        //sound rawr
                        counter++;
                    }
                    
                    else if(counter == 1)
                    {
                        FallinTitle(frame,-1.9f);
                        counter++;
                    }

                    else if(counter == 2)
                    {
                        FallinTitle(frame2,1.5f);
                        counter++;
                    }

                    else if(counter == 3)
                    {
                        FallinTitle(frame3,2.5f);
                        counter++;
                    }

                    else if(counter >= 4)
                    {
                        //sound rawr
                        counter++;
                        PoppingMan();
                    }
                }

                else if(hit2D.collider.CompareTag("Man"))
                {

                    touch++;

                    if(touch >= 3 && appleOn == false)
                    {
                        myTween.Kill();
                        //sound of hit (comical one?)
                        //apple.GetComponent<SpriteRenderer>().enabled = true;
                        appleOn = true;
                    }
                    else if(appleOn == true)
                    {
                        SceneManager.LoadScene("Ball'nBird");
                    }

                }
            }
        }
    }

    void FallinTitle(GameObject frames,float position)
    {
        myTween = frames.transform.DOMoveY(position,1).SetEase(Ease.OutBounce);
    }

    void PoppingMan()
    {
        myTween = man.transform.DOMoveY(0f,1.5f).OnComplete(() => {
                    man.transform.DOMoveY(-5f,1).OnComplete(() => {
                        man.transform.DOMoveX(Random.Range(5f,20f),1).OnComplete(PoppingMan);
                    });
            });

        //fonction récursive -> kill when condition done -> animation du chapeau
    }

}
