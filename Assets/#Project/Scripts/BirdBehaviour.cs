using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]

public class BirdBehaviour : MonoBehaviour
{
    [SerializeField] float _birdAnimDuration = 1.8f;
    [HideInInspector] public Tween myTween;
    [SerializeField] Ease _easeType;
    [SerializeField] float _minDistanceX = 5;
    [SerializeField] float _minDistanceY = 5;
    float _restartLoop = 0;
    Vector3 _currentPosition;
    Vector3 _nextPosition;
    Animator _birdAnimation;
    [HideInInspector] public bool canBeClicked = true;
    [SerializeField] SceneChanger _sceneChanger;
    [SerializeField] Vector3 _lastPosition;
    AudioManager _mySound;
    SpriteRenderer _birdSprite;
    ClickDetection _clickDetection;
    //bool _lastClickedBird;

    void Awake()
    {
        gameObject.SetActive(false);
        _mySound = FindObjectOfType<AudioManager>();
    }
    void Start()
    {
        _birdAnimation = gameObject.GetComponent<Animator>();
        _nextPosition = new Vector3(Random.Range(-8.1f, 8.3f), Random.Range(-2.4f, 4f), 0);
        _birdSprite = gameObject.GetComponent<SpriteRenderer>();
        _clickDetection = FindObjectOfType<ClickDetection>();
    }

    void Flip()
    {
        Vector3 birdScale = transform.localScale;
        birdScale.x *= -1;
        transform.localScale = birdScale;
    }
    
    public void Fly()
    {
        if(_nextPosition.x < transform.position.x && transform.localScale.x == 1)
            Flip();

        else if(_nextPosition.x > transform.position.x && transform.localScale.x == -1)
            Flip();

        _mySound.Play("BirdFlying");
        myTween = transform.DOMove(_nextPosition, _birdAnimDuration).SetEase(_easeType).OnComplete(() => {
            _currentPosition = _nextPosition;
            _nextPosition = new Vector3(Random.Range(-8.1f, 8.3f), Random.Range(-2.4f, 4f), 0);
            _restartLoop = 0;
            while(_restartLoop <= 100)
            {
                if(_currentPosition.x + _minDistanceX <= _nextPosition.x || _currentPosition.y + _minDistanceY <= _nextPosition.y) //si la distance sst trop petite
                {
                    _nextPosition = new Vector3(Random.Range(-8.1f, 8.3f), Random.Range(-2.4f, 4f), 0);//trouve une atre position
                    _restartLoop++;
                }
                else
                    break;

            }
            Fly();

        });
    }
    public void SelectBird()
    {
        if (canBeClicked)
        {
            _mySound.Play("BirdClicked");
            _clickDetection.birds.Add(gameObject);
            _clickDetection.clickedOnce++;
            canBeClicked = false;
            _birdSprite.DOColor(new Color (0.3f, 0.4f, 0.6f, 1f), 0.2f);
            //_lastClickedBird = true;
        }
    }
    //fonction pour détecter les click
    //play sound
    //si can be clicked = true --> lance la fonction
    //change color
    public void StopAndExpand()
    {
        transform.DOMove(_lastPosition, 0.5f).OnComplete(() => {
            transform.DOScale(42, 0.8f);
            _mySound.Play("ExplodingBird");
            StartCoroutine(_sceneChanger.ChangeScene());
        });
    }
}
