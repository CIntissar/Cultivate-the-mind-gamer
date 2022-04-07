using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BallEvent : MonoBehaviour
{
    [SerializeField] List<GameObject> birds = new List<GameObject>(); 
    [HideInInspector] bool isMoving = false;
    Vector3 currentRotation;
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
        if(isMoving == false && clickCount < 3)
        {
            isMoving = true;
            //sound : ball rolling
            FindObjectOfType<AudioManager>().Play("RollingStone");
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
        FindObjectOfType<AudioManager>().Play("Pop");
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
