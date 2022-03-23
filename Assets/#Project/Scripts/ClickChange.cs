using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ClickChange : MonoBehaviour
{
    
    [HideInInspector] public Tween myTween;

    public bool pupilOn = false;
    public GameObject cloud_1;
    public GameObject cloud_2;
    public GameObject cloud_3;
    public GameObject cloud_4;
    public GameObject cloud_5;
    public GameObject cloud_6;
    public float hideSpeed = 1f;
    public int counter = 0;

    void Update()
    {
        transform.position += new Vector3(2, 0, 0);

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if (hit2D.collider != null)
            {
                if(counter <= 6)
                {
                    if(hit2D.collider.CompareTag("Cloud_1"))
                    {
                        Debug.Log("Ceci n'est pas UNO");
                        
                        myTween = cloud_1.transform.DOPunchScale(new Vector3 (0.85f,0.85f,0),hideSpeed, 2, 2f).OnComplete(() => {
                        cloud_1.transform.DOScale(0, 0.25f);
                        });

                        cloud_1.SetActive(false);
                        counter++;

                    }
                    else if(hit2D.collider.CompareTag("Cloud_2"))
                    {
                        Debug.Log("Ceci n'est pas DUO");
                        
                        myTween = cloud_2.transform.DOPunchScale(new Vector3 (0.85f,0.85f,0),hideSpeed, 2, 2f).OnComplete(() => {
                        cloud_2.transform.DOScale(0, 0.25f);
                        });

                        cloud_2.SetActive(false);
                        counter++;
                    }
                    
                    else if(hit2D.collider.CompareTag("Cloud_3"))
                    {
                        Debug.Log("Ceci n'est pas TRE");
                        
                        myTween = cloud_3.transform.DOPunchScale(new Vector3 (0.85f,0.85f,0),hideSpeed, 2, 2f).OnComplete(() => {
                        cloud_3.transform.DOScale(0, 0.25f);
                        });

                        cloud_3.SetActive(false);
                        counter++;
                    }
                    
                    else if(hit2D.collider.CompareTag("Cloud_4"))
                    {
                        Debug.Log("Ceci n'est pas QUATTRO");
                        
                        myTween = cloud_4.transform.DOPunchScale(new Vector3 (0.85f,0.85f,0),hideSpeed, 2, 2f).OnComplete(() => {
                        cloud_4.transform.DOScale(0, 0.25f);
                        });

                        cloud_4.SetActive(false);
                        counter++;
                    }
                    
                    else if(hit2D.collider.CompareTag("Cloud_5"))
                    {
                        Debug.Log("Ceci n'est pas CINQUE");
                        
                        myTween = cloud_5.transform.DOPunchScale(new Vector3 (0.85f,0.85f,0),hideSpeed, 2, 2f).OnComplete(() => {
                        cloud_5.transform.DOScale(0, 0.25f);
                        });

                        cloud_5.SetActive(false);
                        counter++;
                    }
                    
                    else if(hit2D.collider.CompareTag("Cloud_6"))
                    {
                        Debug.Log("Ceci n'est pas SEI");
                        
                        myTween = cloud_6.transform.DOPunchScale(new Vector3 (0.85f,0.85f,0),hideSpeed, 2, 2f).OnComplete(() => {
                        cloud_6.transform.DOScale(0, 0.25f);
                        });

                        cloud_6.SetActive(false);
                        counter++;
                    }
                }
                pupilOn = true;

            }
        }
    }
}
