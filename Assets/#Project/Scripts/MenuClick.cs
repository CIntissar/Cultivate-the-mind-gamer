using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using DG.Tweening;

public class MenuClick : MonoBehaviour
{
    // THOMAS : all of these variable can be private since they are not used outside of this class
    // To show private variables in the inspector do this:
    // [SerializeField] private int _touch;
    // private fields always start with underscore _
    
    public int touch = 0;
    public int counter = 0;
    public int limitTouch = 3;
    public SpriteRenderer quote;
    public GameObject man;
    public GameObject hat;
    public GameObject lion;
    public GameObject apple;
    public GameObject frame;
    public GameObject frame2;
    public GameObject frame3;
    public bool appleOn = false;
    public bool clickedOnce = false;
    public AnimMenu animMenu;

    [HideInInspector] public Tween myTween; // THOMAS: make it private?

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if (hit2D.collider != null)
            {
                                
                if(hit2D.collider.CompareTag("Lion")) //lion
                {
                    if(counter == 0)
                    {
                        //animation -> Lion Appear!
                        lion.transform.DOMoveX(transform.position.x + 1.25f,1f);
                        FindObjectOfType<AudioManager>().Play("LionRawr");
                        counter++;
                        //reveal quote
                        quote.DOFade(1f, 2f);
                    }
                    
                    else if(counter == 1) //lion
                    {
                        FallinTitle(frame,-1.9f);
                        FindObjectOfType<AudioManager>().Play("PaintingFall");
                        counter++;
                    }
                    
                    FindObjectOfType<AudioManager>().Play("LionPurr");
                    // else if(counter == 2)
                    // {
                    //     FallinTitle(frame2,1.5f);
                    //     FindObjectOfType<AudioManager>().Play("PaintingFall");
                    //     counter++;
                    // }

                    // else if(counter == 3)
                    // {
                    //     FallinTitle(frame3,2.5f);
                    //     FindObjectOfType<AudioManager>().Play("PaintingFall");
                    //     counter++;
                    // }

                    // else if(counter >= 4)
                    // {
                    //     FindObjectOfType<AudioManager>().Play("LionPurr");
                    //     counter++;
                    //     PoppingMan();
                    // }
                }

                if(hit2D.collider.CompareTag("FrameFall1")) //"jeux vidéo"
                {
                    if(counter == 2)
                    {
                        //THOMAS: 1.5f is what they call a magic value. If someone else reads this he has no idea what 1.5f means
                        // rename position to yPos and show these as variables in the inspector OR
                        // create transforms in the scene, and use these as variables in this script to pass to the FallinTitle.
                        // Then fallintitle takes the transform.position.y as a destination.
                        FallinTitle(frame2,1.5f); 
                        
                        //THOMAS: cache AudioManager in Awake
                        FindObjectOfType<AudioManager>().Play("PaintingFall");
                        counter++;
                    }
                }

                if(hit2D.collider.CompareTag("FrameFall2")) //"ceci"
                {
                     if(counter == 3)
                    {
                        FallinTitle(frame3,2.5f);
                        FindObjectOfType<AudioManager>().Play("PaintingFall");
                        counter++;
                    }
                }

                if(hit2D.collider.CompareTag("FrameFall3"))
                {
                    if(counter >= 4 && clickedOnce == false)
                    {
                        counter++;
                        PoppingMan();
                        FindObjectOfType<AudioManager>().Play("HeyThere");
                        clickedOnce = true;
                        
                    }
                }

                if(hit2D.collider.CompareTag("Man"))
                {
                    touch++;
                    FindObjectOfType<AudioManager>().Play("Hat");
                    animMenu.animator.SetTrigger("hatJump");

                    if(touch >= 3 && appleOn == false)
                    {
                        myTween.Kill();
                        //sound of hit (comical one?)
                        //apple.GetComponent<SpriteRenderer>().enabled = true;
                        appleOn = true;
                        
                        // THOMAS: why no start the AnimMenu animation from here?
                    }
                    else if(appleOn == true)
                    {
                        // THOMAS: try to no use to many funny characters like ' " : \ / in names
                        // It might have worked now but you got lucky :)
                        SceneManager.LoadScene("Ball'nBird");
                    }
                }

            }
        }
    }

    void FallinTitle(GameObject frames,float position)
    {
        //sound : falling object
        myTween = frames.transform.DOMoveY(position,1).SetEase(Ease.OutBounce);
    }

    void PoppingMan()
    {
        myTween = man.transform.DOMoveY(0f,1.5f).OnComplete(() => {
                    man.transform.DOMoveY(-5f,1).OnComplete(() => {
                        // THOMAS: little detail but this last move is invisible to the player right?
                        // So you could just 'set' the X value of the position iso doing an animation and then wait a second.
                        // Check out Sequences in DoTween.
                        man.transform.DOMoveX(Random.Range(5f,20f),1).OnComplete(PoppingMan);
                    });
            });

        //fonction récursive -> kill when condition done -> animation du chapeau
    }

}
