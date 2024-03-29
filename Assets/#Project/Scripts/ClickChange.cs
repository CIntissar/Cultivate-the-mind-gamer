using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine;
using DG.Tweening;

public class ClickChange : MonoBehaviour
{
    
    [HideInInspector] public Tween myTween;

    public BalltoEye balltoEye;
    public int counter = 0;
    public int pokingCount = 0;
    public float hideSpeed = 1f;

    public bool poke1 = false;
    public bool poke2 = false;
    public bool poke3 = false;

    public bool pupilOn = false;
    public bool oceanUp = false;
    public bool uiTouched = false;
    public bool cloudHiding = false;
    public bool pokingTransition = false;

    public GameObject cloud_1;
    public GameObject drop;
    public GameObject cloud_2;
    public GameObject drop2;
    public GameObject cloud_3;
    public GameObject drop3;
    public GameObject cloud_4;
    public GameObject drop4;
    public GameObject cloud_5;
    public GameObject drop5;
    public GameObject cloud_6;
    public GameObject drop6;
    public GameObject ocean;
    
    void Start()
    {
        FindObjectOfType<AudioManager>().StopPlaying("ForestAmbiance");
        FindObjectOfType<AudioManager>().StopPlaying("BirdFlying");
        FindObjectOfType<AudioManager>().Play("BeachAmbiance");
    }
    void Update()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if(EventSystem.current.IsPointerOverGameObject())
            {
                counter += 0;
                uiTouched = true;
            }
            else
            {
                uiTouched = false;
            }

            if (hit2D.collider != null)
            {
                if(!EventSystem.current.IsPointerOverGameObject() && EventSystem.current.currentSelectedGameObject == null){

                    if(hit2D.collider.CompareTag("Cloud_1"))
                    {
                        Debug.Log("Ceci n'est pas UNO");
                        //sound : cloud disappear
                        // THOMAS: Create Cloud script , move ShrinkCloud to Cloud script
                        
                        ShrinkCloud(cloud_1);
                        
                        // THOMAS: same for Ocean and then call Ocean.Rise()
                        // THOMAS: same for drop
                        // THOMAS: then add ClickInterface on cloud + call IncreaseCounter on ClickChange that increments counter
                        
                        StartCoroutine(RiseOcean(drop));
                        counter++;                    

                    }
                    else if(hit2D.collider.CompareTag("Cloud_2"))
                    {
                        Debug.Log("Ceci n'est pas DUO");
                        //sound : cloud disappear
                        ShrinkCloud(cloud_2);
                        StartCoroutine(RiseOcean(drop2)); 
                        counter++;

                    }
                    
                    else if(hit2D.collider.CompareTag("Cloud_3"))
                    {
                        Debug.Log("Ceci n'est pas TRE");
                        //sound : cloud disappear
                        ShrinkCloud(cloud_3);
                        //HideCloud(cloud_3);
                        StartCoroutine(RiseOcean(drop3)); 
                        counter++;

                    }
                    
                    else if(hit2D.collider.CompareTag("Cloud_4"))
                    {
                        Debug.Log("Ceci n'est pas QUATTRO");
                        //sound : disapear
                        ShrinkCloud(cloud_4);
                        StartCoroutine(RiseOcean(drop4));   
                        counter++;                  

                    }
                    
                    else if(hit2D.collider.CompareTag("Cloud_5"))
                    {
                        Debug.Log("Ceci n'est pas CINQUE");
                        //sound : disappear
                        ShrinkCloud(cloud_5);
                        StartCoroutine(RiseOcean(drop5));   
                        counter++;                 

                    }
                    
                    else if(hit2D.collider.CompareTag("Cloud_6"))
                    {
                        Debug.Log("Ceci n'est pas SEI");
                        //sound : disappear
                        ShrinkCloud(cloud_6);
                        StartCoroutine(RiseOcean(drop6)); 
                        counter++;
                        
                    }

                    if(counter >= 6)
                    {
                        pupilOn = true;
                        oceanUp = true;
                    }

                    if(hit2D.collider.CompareTag("Skin"))
                    {
                        pokingCount++;
                        pupilOn = false;

                        if(pokingCount == 1)
                        {
                            FindObjectOfType<AudioManager>().Play("Ouch1");
                            Debug.Log("OUTCH!!!");
                            pokingTransition = true;
                            //sound of hurting!
                        }
                        else if(pokingCount == 2)
                        {
                            FindObjectOfType<AudioManager>().Play("Ouch2");
                            poke1 = true;
                            //Poke(); -> je dois en créer un autre pour que le perso avance + new background                        
                            //sound of hurting again
                        }
                        else if(pokingCount == 3)
                        {
                            FindObjectOfType<AudioManager>().Play("Ouch3");
                            poke2 = true;
                            // Poke à nouveau, le perso parait plus clair et encore décor différent
                            //sound of hurting again more
                        }
                        else if(pokingCount == 4)
                        {
                            FindObjectOfType<AudioManager>().Play("Ouch1");
                            poke3 = true;
                            //SceneManager.LoadScene("GiantHead");
                        }
                        else if(pokingCount > 4)
                        {
                            SceneManager.LoadScene("GiantHead");
                        }
                    }
                }
           
            }
        }
    }

    public void ShrinkCloud(GameObject clouds)
    {
        myTween = clouds.transform.DOPunchScale(new Vector3 (0.85f,0.85f,0),hideSpeed, 1, 2f).OnComplete(() => {
                    clouds.transform.DOScale(0, 0.35f).OnComplete(() => {
                        clouds.gameObject.SetActive(false);
                    });
        });
    }

    public IEnumerator RiseOcean(GameObject waterdrop)
    {
        //waterdrop.SetActive(true);
        waterdrop.GetComponent<SpriteRenderer>().enabled = true;
        Debug.Log("I CAME IN LIKE A WRECKINGBALL");
        myTween = waterdrop.transform.DOMoveY(-15f,3f);
        ocean.transform.Translate(0,0.5f,0);
        yield return new WaitForSeconds(0.8f);
        FindObjectOfType<AudioManager>().Play("WaterDrop");
    }
    
}
