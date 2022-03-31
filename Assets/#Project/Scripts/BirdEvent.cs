using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class BirdEvent : MonoBehaviour
{
    public SpriteRenderer sprite;
    [SerializeField] float birdAnimDuration = 1.8f;
    [HideInInspector] public Tween myTween;
    [SerializeField] Ease easeType;
    [SerializeField] float minDistanceX = 3;
    [SerializeField] float minDistanceY = 3;
    float restartLoop = 0;
    Vector3 currentPosition;
    Vector3 nextPosition;
    void Awake()
    {
        sprite = GameObject.FindGameObjectWithTag("whiteSprite").GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        nextPosition = new Vector3(Random.Range(-8.1f, 8.3f), Random.Range(-2.4f, 4f), 0);
    }

    void Update()
    {
        
    }
    public void Fly()
    {
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
        //inside while loop --> make sure the min distance between both position is respected
        //if not, restart the loop
        //"if the distance of both position is smaller than the min distance AND the loop hasn't restarted 100 times --> restart the loop"
    }
    public void StopAndExpand()
    {
        myTween.Kill();
        transform.DOMove(Vector3.zero, 0.5f).OnComplete(() => {
            transform.DOScale(30, 1f).OnComplete(() => {
                sprite.DOFade(1,0.9f).OnComplete(() => {
                    SceneManager.LoadScene("Dot on sea");
                });
            });
        });
    }
}
