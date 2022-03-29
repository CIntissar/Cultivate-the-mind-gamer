using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class BirdEvent : MonoBehaviour
{
    Animator animator;
    public SpriteRenderer sprite;
    public float birdAnimDuration = 2f;
    [HideInInspector] public Tween myTween;
    public Ease easeType;
    //public PathType pathSystem = PathType.CatmullRom;
    public Vector2[] pathval = new Vector2[5];
    //public List<int> randomNumbersList = new List<int>(5);
    //public int nbrCopy;
    public int nbr;
    void Awake()
    {
        animator = GetComponent<Animator>();
        sprite = GameObject.FindGameObjectWithTag("whiteSprite").GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        //nbrCopy = Random.Range(0,4);
        nbr = Random.Range(0,4);
    }

    void Update()
    {
        
    }
    public void Fly()
    {
        myTween = transform.DOMove(new Vector2(pathval[nbr].x, pathval[nbr].y), birdAnimDuration).SetEase(easeType).OnComplete(Fly);
        //myTween = transform.DOLocalPath(pathval, 2, pathSystem);
        // myTween = transform.DOMove(new Vector3 (Random.Range(-8.1f, 8.3f), Random.Range(-2.4f, 4f), 0), birdAnimDuration).SetEase(easeType).OnComplete(Fly);
        //if smooth later on doesn't work, try using DOPath
    }
    public void StopAndExpand()
    {
        myTween.Kill();
        transform.DOMove(Vector3.zero, 0.5f).OnComplete(() => {
            transform.DOScale(20, 1f).OnComplete(() => {
                sprite.DOFade(1,1).OnComplete(() => {
                    SceneManager.LoadScene("Dot on sea");
                });
            });
        });
    }
}
