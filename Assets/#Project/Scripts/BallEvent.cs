using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


// THOMAS : this is not an event-related class so better rename it to BallBehaviour
// event is a specific thing in c#
public class BallEvent : MonoBehaviour
{
    // THOMAS : all of these variable can be private since they are not used outside of this class
    // To show private variables in the inspector do this:
    // [SerializeField] private int _touch;
    // private fields always start with underscore _
    
    [SerializeField] List<GameObject> birds = new List<GameObject>(); 
    [HideInInspector] bool isMoving = false;
    Vector3 currentRotation;
    // THOMAS: clickCount can be made private cause it's not use outside of this class
    // THOMAS: clickCount should be an int not a float?
    [HideInInspector] public float clickCount = 0; 
    [SerializeField] Transform upperBall;
    SpriteRenderer[] spriteRenderers;
    [SerializeField] SpriteRenderer quote;
    void Start()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }
    void Update()
    {
        
    }
    public IEnumerator RollOver()
    {
        // THOMAS: move this check outside
        if(isMoving == false && clickCount < 3)
        {
            isMoving = true;
            //sound : ball rolling
            
            // THOMAS : cache AudioManager in Awake or at least test it for null. 
            // Nowadays you can use the conditional access ? operator. This check if the thing before is null and will not execute Play(..) if it is.
            FindObjectOfType<AudioManager>()?.Play("RollingStone");
            currentRotation = transform.eulerAngles;
            transform.DOMoveX(transform.position.x + 4f, 2f);
            transform.DORotate(new Vector3 (0, 0, currentRotation.z - 120f), 2f);
            transform.DOScale(new Vector3(transform.localScale.x + 0.4f, transform.localScale.y + 0.4f, 0), 2f);
            yield return new WaitForSeconds(2f);
            isMoving = false;
            clickCount++;

            if(clickCount == 3) //if it rolled 3 times
            {
                StartCoroutine(OpenUpAndFly()); //balls opens up and bird starts flying
            }
        }
        
    }
    public IEnumerator OpenUpAndFly()
    {
        //sound : ball pops up
        FindObjectOfType<AudioManager>()?.Play("Pop");
        upperBall.DOMoveY(transform.position.y + 3f, 0.8f).OnComplete(() => {
            quote.DOFade(0, 0.5f);
            foreach (GameObject item in birds)
            {
                item.GetComponent<SpriteRenderer>().DOFade(1, 0.1f);
            }
            foreach (SpriteRenderer rend in spriteRenderers)
            {
                rend.DOFade(0, 0.5f);
            }
            foreach (GameObject item in birds)
            {
                item.GetComponent<BirdEvent>().Fly();
            }
        });
        yield return new WaitForSeconds(1.2f);
        gameObject.SetActive(false);
    }
}
