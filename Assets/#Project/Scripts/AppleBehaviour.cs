using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AppleBehaviour : MonoBehaviour
{
    [HideInInspector] public SpriteRenderer rend;
    public Sprite greenAppleSprite;
    public bool spriteChanged = false;
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        
    }
    public void ChangeSprite()
    {
        rend.sprite = greenAppleSprite;
        spriteChanged = true;
    }
}
