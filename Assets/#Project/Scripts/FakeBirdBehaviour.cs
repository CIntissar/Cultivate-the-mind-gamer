using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FakeBirdBehaviour : MonoBehaviour
{
    //public List<Transform> fakeBirds = new List<Transform>();
    //public SpriteRenderer fakeBirdsSprite;
    //public float[] birdSpeed; //place numbers
    [SerializeField] Transform[] routes; //where the curve are stored
    int routeToGo = 0; //next index to follow
    float tParam = 0f;
    [SerializeField] Vector2 birdPosition; //position of the bird
    public float SpeedModifier = 0.5f;
    public bool CoroutineAllowed = true; //prevents a coroutine from running before the last one ends
    [SerializeField] BirdEvent birdEvent;
    //RaycastHit2D hit2D;
    //Ray ray;
    void Start()
    {
        
    }
    void Update()
    {
        //ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //hit2D = Physics2D.GetRayIntersection(ray);
        // if (birdEvent.isFlying)
        // {
        //     if (CoroutineAllowed)
        //     {
        //         StartCoroutine(GoByTheRoute(routeToGo));
        //     }
        // }
    }
    public IEnumerator GoByTheRoute(int routeNumber)
    {
        print("coroutine starts");
        CoroutineAllowed = false;

        Vector2 p0 = routes[routeNumber].GetChild(0).position;
        Vector2 p1 = routes[routeNumber].GetChild(1).position;
        Vector2 p2 = routes[routeNumber].GetChild(2).position;
        Vector2 p3 = routes[routeNumber].GetChild(3).position;

        tParam += Time.deltaTime * SpeedModifier; //gives smooth movement along the curve
        while (tParam < 1) //calculate the birds position depending on the value of t
        {
            print("inside while");
            birdPosition = Mathf.Pow(1 - tParam, 3) * p0 + 3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 + 3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 + Mathf.Pow(tParam, 3) * p3;
            if(birdPosition.x < transform.position.x && transform.localScale.x == 1)
            {
            Flip();
            }
            else if(birdPosition.x > transform.position.x && transform.localScale.x == -1)
            {
                Flip();
            }
            transform.position = birdPosition;
            yield return new WaitForEndOfFrame();
        }
        tParam = 0f;

        routeToGo += 1; //goes along the next curve

        if(routeToGo > routes.Length - 1) //if the cat completes the last route, set route to go back to 0 so it will go by the first route
            routeToGo = 0;

        CoroutineAllowed = true;
    }
    // public void FadeIn()
    // {
    //     fakeBirdsSprite.DOFade(1, 0.1f);
    // }
    void Flip()
    {
        Vector3 birdScale = transform.localScale;
        birdScale.x *= -1;
        transform.localScale = birdScale;
        
    }
    // void ChangeSpeed()
    // {
    //     for (int i = 0; i < fakeBirds.Count; i++)
    //     {
    //         SpeedModifier += 0.5f;
    //     }
    // }
    // public void DestroyBird()
    // {
    //     Destroy(gameObject);
    // }
}
