using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SceneChanger : MonoBehaviour
{
    public SpriteRenderer sprite;
    void Start()
    {
        sprite = GameObject.FindGameObjectWithTag("whiteSprite").GetComponent<SpriteRenderer>();
    }
    public IEnumerator ChangeScene()
    {
        sprite.DOFade(1, 0.9f);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Dot on sea");
    }
}
