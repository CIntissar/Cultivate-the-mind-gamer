using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class BalltoEye : MonoBehaviour
{
    //Script to make the pupil float after one click -> Poke the eyes and make the man come closer
    public int clickCount = 0;
    public bool arrowAway = false;
    public bool blinkTransition = false;
    public GameObject pupil;
    public Animator animator;
    public ClickChange clickChange;
    public MovingCamera movingCamera;

    void Start()
    {
        animator.SetBool("outSea", true);
    }

    void Update()
    {
        // if(movingCamera.pupilAnimation == true)
        // {
        //     animator.SetBool("outSea", true);
        // }
        // else if(movingCamera.pupilAnimation == false)
        // {
        //     animator.SetBool("outSea", false);
        // }
        
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

            if (hit2D.collider != null)
            {
                if(movingCamera.ballCenter == true && hit2D.collider.CompareTag("Pupil"))
                {
                    Debug.Log("DON'T TOUCH ME!!!");

                    clickCount++;

                    if(clickCount == 1)
                    {
                        animator.SetBool("outSea", false);
                        FindObjectOfType<AudioManager>().Play("PupilAscend");
                        //FloatingBall();
                        arrowAway = true;
                    }
                    // else if(clickCount == 2)
                    // {
                    //     blinkTransition = true;
                    // }
                }

                // if(hit2D.collider.CompareTag("Skin"))
                // {
                //     pokingCount++;

                //     if(pokingCount == 1)
                //     {
                //         Debug.Log("OUTCH!!!");
                //         pokingTransition = true;
                //         //sound of hurting!
                //     }
                //     else if(pokingCount == 2)
                //     {
                //         poke1 = true;
                //         //Poke(); -> je dois en créer un autre pour que le perso avance + new background                        
                //         //sound of hurting again                        
                //     }
                //     else if(pokingCount == 3)
                //     {
                //         poke2 = true;
                //         // Poke à nouveau, le perso parait plus clair et encore décor différent
                //         //sound of hurting again more
                //     }
                //     else if(pokingCount >= 4)
                //     {
                //         poke3 = true;
                //         //Last Poke
                //         SceneManager.LoadScene("GiantHead");

                //     }
                // }
            }
        }
    }

    // void FloatingBall()
    // {
    //     pupil.transform.DOMoveY(transform.position.y + 4.5f, 2f);
    // }



        
}
