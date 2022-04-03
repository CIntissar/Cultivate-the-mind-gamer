using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FakeBirdBehaviour : MonoBehaviour
{
    public SpriteRenderer[] birdsSprite;
    [SerializeField] List<Transform> fakeBirds = new List<Transform>();
    [SerializeField] float birdAnimDuration = 1.8f;
    [HideInInspector] public Tween myTween;
    [SerializeField] Ease easeType;
    [SerializeField] float minDistanceX = 5;
    [SerializeField] float minDistanceY = 5;
    float restartLoop = 0;
    Vector3 currentPosition;
    Vector3 nextPosition;
    RaycastHit2D hit2D;
    Ray ray;
    void Start()
    {
        nextPosition = new Vector3(Random.Range(-8.1f, 8.3f), Random.Range(-2.4f, 4f), 0);
    }
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hit2D = Physics2D.GetRayIntersection(ray);
    }
    public void StartFlying()
    {
        for (int i = 0; i < fakeBirds.Count; i++)
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
            });
        }
        StartFlying();
    }
    public void FadeIn()
    {
        foreach (SpriteRenderer item in birdsSprite)
        {
            item.DOFade(1, 0.1f);
        }
    }
    public void DestroyBird()
    {
        for (int i = 0; i < fakeBirds.Count; i++)
        {
            if(hit2D.collider.gameObject == fakeBirds[i].gameObject)
            {
                Destroy(fakeBirds[i]);
            }
        }
    }
}
