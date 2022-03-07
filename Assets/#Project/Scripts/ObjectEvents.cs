using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectEvents : MonoBehaviour
{
    public string objectTag = "Ball";
    public bool isMoving = false;
    public Vector3 currentRotation;
    public float clickCount = 0;
    public Transform upperBall;
    public Transform bird;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator RollOver()
    {
        if(isMoving == false && clickCount < 3)
        {
            isMoving = true;
            currentRotation = transform.eulerAngles;
            transform.DOMoveX(transform.position.x + 4f, 2f);
            transform.DORotate(new Vector3 (0, 0, currentRotation.z - 120f), 2f);
            transform.DOScale(new Vector3(transform.localScale.x + 0.4f, transform.localScale.y + 0.4f, 0), 2f);
            yield return new WaitForSeconds(2f);
            isMoving = false;
            clickCount++;
        }
    }
    public IEnumerator OpenUp()
    {
        upperBall.DOMoveY(transform.position.y + 3f, 1f);
        yield return new WaitForSeconds(0.9f);
        Fly();
    }
    public void Fly()
    {
        bird.DOMove(new Vector3 (Random.Range(0, 14), Random.Range(1, 6.5f), 0), 1f);
    }
}
