using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ClickDetection : MonoBehaviour
{
    [SerializeField] BallBehaviour _ballBehaviour;
    [SerializeField] GameObject _ball;
    [SerializeField] List<GameObject> _birds = new List<GameObject>();
    [SerializeField] SpriteRenderer[] _birdSprites;
    float _clickedOnce = 0;
    AudioManager _mySound;
    void Start()
    {
        _mySound = FindObjectOfType<AudioManager>();
        _mySound.Play("ForestAmbiance");
        _ballBehaviour = _ball.GetComponent<BallBehaviour>();
    }
    void Update()
    {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D _hit2D = Physics2D.GetRayIntersection(_ray);
        
        if(Input.GetMouseButtonDown(0))
        {
            if (_hit2D.collider != null) //if the ray hits something
            {
                if (_hit2D.collider.CompareTag("Ball")) //if that something is the ball
                {
                    StartCoroutine(_ballBehaviour.RollOver()); //the ball rolls
                    
                    // THOMAS: check clickcount here, not inside RollOver
                    // This is a detail but you could argue that the moment you call RollOver you assume the ball will rollover and it doesn't fail.
                    // THOMAS: if(isMoving == false && clickCount < 3)
                }
                for (int i = 0; i < _birds.Count; i++)
                {
                    if(_hit2D.collider.gameObject == _birds[i].gameObject && _birds[i].GetComponent<BirdBehaviour>().canBeClicked)
                    {
                        _mySound.Play("BirdClicked");
                        _clickedOnce += 1;
                        _birds[i].GetComponent<BirdBehaviour>().canBeClicked = false;
                        _birdSprites[i].DOColor(new Color (0.3f, 0.4f, 0.6f, 1f), 0.2f);
                        print(_clickedOnce);
                        if(_clickedOnce >= _birds.Count)
                        {
                            KillAllTweens();
                            _birds[i].GetComponent<BirdBehaviour>().StopAndExpand();
                        }
                    }
                }
            }
            else
                Debug.Log("there's nothing here...");

        }
        
    }
    void KillAllTweens()
    {
        for (int i = 0; i < _birds.Count; i++)
        {
            _birds[i].GetComponent<BirdBehaviour>().myTween.Kill();
        }
    }
    // void InvokeMyCoroutine()
    // {
    //     StartCoroutine(_ballBehaviour.RollOver()); //the ball rolls

    // }
}
