using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AppleBehaviour : MonoBehaviour
{
    SpriteRenderer _rend;
    [SerializeField] Sprite _greenAppleSprite;
    [HideInInspector] public bool spriteChanged = false;
    void Start()
    {
        _rend = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        
    }
    public void ChangeSprite()
    {
        _rend.sprite = _greenAppleSprite;
        spriteChanged = true;
    }
}
