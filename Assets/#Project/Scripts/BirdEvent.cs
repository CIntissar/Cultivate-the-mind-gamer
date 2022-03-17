using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class BirdEvent : MonoBehaviour
{
    Animator animator;
    public Animator transition;
    public float transitionTime = 1f;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        //anim = GetComponent<Animation>();
    }

    void Update()
    {
        
    }
    public void Fly()
    {
        //transform.DOMove(new Vector3 (0f, 0f, 0), 0.5f);
        animator.SetBool("GoCenter", true);
        animator.SetBool("isFlying", true);
    }
    public void StopAndExpand()
    {
        animator.SetBool("Growth", true);
        LoadNextLevel();
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
        transition.SetTrigger("end");
    }
}
