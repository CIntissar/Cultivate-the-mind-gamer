using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]
public class BirdEvent : MonoBehaviour
{
    [SerializeField] float birdAnimDuration = 1.8f;
    [HideInInspector] public Tween myTween;
    [SerializeField] Ease easeType;
    [SerializeField] float minDistanceX = 5;
    [SerializeField] float minDistanceY = 5;
    float restartLoop = 0;
    Vector3 currentPosition;
    Vector3 nextPosition;
    Animator birdAnimation;
    public bool canBeClicked = true;
    public SceneChanger sceneChanger;

    void Start()
    {
        birdAnimation = gameObject.GetComponent<Animator>();
        nextPosition = new Vector3(Random.Range(-8.1f, 8.3f), Random.Range(-2.4f, 4f), 0);
    }
    public void Fly()
    {
        //sound : bird flying
        if(nextPosition.x < transform.position.x && transform.localScale.x == 1)
        {
            Flip();
        }
        else if(nextPosition.x > transform.position.x && transform.localScale.x == -1)
        {
            Flip();
        }
        FindObjectOfType<AudioManager>().Play("BirdFlying");
        myTween = transform.DOMove(nextPosition, birdAnimDuration).SetEase(easeType).OnComplete(() => {
            currentPosition = nextPosition;
            nextPosition = new Vector3(Random.Range(-8.1f, 8.3f), Random.Range(-2.4f, 4f), 0);
            restartLoop = 0;
            while(restartLoop <= 100)
            {
                if(currentPosition.x + minDistanceX <= nextPosition.x || currentPosition.y + minDistanceY <= nextPosition.y) //si la distance sst trop petite
                {
                    nextPosition = new Vector3(Random.Range(-8.1f, 8.3f), Random.Range(-2.4f, 4f), 0);//trouve une atre position
                    restartLoop++;
                }
                else
                {
                    break;
                }
            }
            Fly();

        });
    }
    public void StopAndExpand()
    {
        //birdAnimation.enabled = false;
        //myTween.Kill();
        transform.DOMove(Vector3.zero, 0.5f).OnComplete(() => {
            //sound : explode ? ou wosh
            FindObjectOfType<AudioManager>().Play("ExplodingBird");
            transform.DOScale(35, 1f);
            StartCoroutine(sceneChanger.ChangeScene());
        });
    }
    void Flip()
    {
        Vector3 birdScale = transform.localScale;
        birdScale.x *= -1;
        transform.localScale = birdScale;
    }
}
