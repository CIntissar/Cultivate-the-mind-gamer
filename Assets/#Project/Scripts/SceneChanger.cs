using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] Animator _spriteAnimation;
    void Start()
    {
        
    }
    public IEnumerator ChangeScene()
    {
        _spriteAnimation.SetBool("FadeIn", true);
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene("Dot on sea");
    }
}
