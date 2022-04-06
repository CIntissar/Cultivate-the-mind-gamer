using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Animator spriteAnimation;
    void Start()
    {
        //sprite = GameObject.FindGameObjectWithTag("whiteSprite").GetComponent<SpriteRenderer>();
    }
    public IEnumerator ChangeScene()
    {
        spriteAnimation.SetBool("FadeIn", true);
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene("Dot on sea");
    }
}
