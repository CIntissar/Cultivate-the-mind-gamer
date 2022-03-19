using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class BirdEvent : MonoBehaviour
{
    Animator animator;
    public SpriteRenderer sprite;
    public float birdSpeed = 2f;
    //public Animator transition;
    public float transitionTime = 1f;
    void Awake()
    {
        animator = GetComponent<Animator>();
        sprite = GameObject.FindGameObjectWithTag("whiteSprite").GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void Fly()
    {
        transform.DOMove(new Vector3 (Random.Range(-8.1f, 8.3f), Random.Range(-2.4f, 4f), 0), birdSpeed).OnComplete(Fly); //x=8.3, -8.1 y= -2.4, 4
        //if smooth later on doesn't work, try using DOPath
    }
    public void StopAndExpand()
    {
        transform.DOMove(Vector3.zero, 1f).OnComplete(() => {
            transform.DOScale(20, 1f);
        });

        LoadNextLevel();
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        sprite.DOFade(1,1);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
        sprite.DOFade(0,1);
    }
}
