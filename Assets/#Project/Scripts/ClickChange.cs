using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ClickChange : MonoBehaviour
{
    
    [HideInInspector] public Tween myTween;

    public BalltoEye balltoEye;
    public int counter = 0;
    public bool pupilOn = false;

    public GameObject cloud_1;
    public GameObject drop;
    public GameObject cloud_2;
    public GameObject cloud_3;
    public GameObject drop3;
    public GameObject cloud_4;
    public GameObject drop4;
    public GameObject cloud_5;
    public GameObject drop5;
    public GameObject cloud_6;
    public GameObject drop6;
    public GameObject ocean;
    
    public bool oceanUp = false;
    public float hideSpeed = 1f;
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
                    Debug.Log("Ceci n'est pas UNO");
                    
                    HideCloud(cloud_1);
                    RiseOcean(drop);
                    counter++;                    

                }
                else if(hit2D.collider.CompareTag("Cloud_2"))
                {
                    Debug.Log("Ceci n'est pas DUO");
                    
                    HideCloud(cloud_2);
                    counter++;

                }
                
                else if(hit2D.collider.CompareTag("Cloud_3"))
                {
                    Debug.Log("Ceci n'est pas TRE");
                    
                    HideCloud(cloud_3);
                    RiseOcean(drop3); 
                    counter++;

                }
                
                else if(hit2D.collider.CompareTag("Cloud_4"))
                {
                    Debug.Log("Ceci n'est pas QUATTRO");
                    
                    HideCloud(cloud_4);
                    RiseOcean(drop4);   
                    counter++;                  

                }
                
                else if(hit2D.collider.CompareTag("Cloud_5"))
                {
                    Debug.Log("Ceci n'est pas CINQUE");
                    
                    HideCloud(cloud_5);
                    RiseOcean(drop5);   
                    counter++;                 

                }
                
                else if(hit2D.collider.CompareTag("Cloud_6"))
                {
                    Debug.Log("Ceci n'est pas SEI");
                    
                    HideCloud(cloud_6);
                    RiseOcean(drop6); 
                    counter++;
                    
                }
                
            }
        }

        if(counter >= 6)
        {
            pupilOn = true;
            oceanUp = true;
        }


    }

    public void HideCloud(GameObject clouds)
    {
        myTween = clouds.transform.DOPunchScale(new Vector3 (0.85f,0.85f,0),hideSpeed, 2, 2f).OnComplete(() => {
                    clouds.transform.DOScale(0, 0.35f);
        
        });

        clouds.GetComponent<SpriteRenderer>().enabled = false;
        //clouds.SetActive(false);
    }

    public void RiseOcean(GameObject waterdrop)
    {
        //waterdrop.SetActive(true);
        waterdrop.GetComponent<SpriteRenderer>().enabled = true;
        Debug.Log("I CAME IN LIKE A WRECKINGBALL");
        myTween = waterdrop.transform.DOMoveY(-15f,2f);
        ocean.transform.Translate(0,0.5f,0);
    }
}
