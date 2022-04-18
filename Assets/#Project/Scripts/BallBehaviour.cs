using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BallBehaviour : MonoBehaviour
{
    [SerializeField] List<GameObject> _birds = new List<GameObject>(); 
    bool _isMoving = false;
    int _clickCount = 0;
    Vector3 _currentRotation;
    // THOMAS: clickCount can be made private cause it's not use outside of this class
    [SerializeField] Transform _upperBall;
    SpriteRenderer[] _spriteRenderers;
    [SerializeField] SpriteRenderer _quote;
    AudioManager _mySound;

    void Awake()
    {
        _mySound = FindObjectOfType<AudioManager>();
    }
    void Start()
    {
        _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    void Update()
    {
        
    }
    public IEnumerator RollOver()
    {
        // THOMAS: move this check outside
        if (_isMoving == false && _clickCount < 3)
        {
            _isMoving = true;
            // THOMAS : cache AudioManager in Awake or at least test it for null. 
            // Nowadays you can use the conditional access ? operator. This check if the thing before is null and will not execute Play(..) if it is.
            _mySound.Play("RollingStone");
            _currentRotation = transform.eulerAngles;
            transform.DOMoveX(transform.position.x + 4f, 2f);
            transform.DORotate(new Vector3 (0, 0, _currentRotation.z - 120f), 2f);
            transform.DOScale(new Vector3(transform.localScale.x + 0.4f, transform.localScale.y + 0.4f, 0), 2f);
            yield return new WaitForSeconds(2f);
            _isMoving = false;
            _clickCount++;

            if(_clickCount == 3)
                StartCoroutine(OpenUpAndFly()); //balls opens up and bird starts flying

        }
        
    }
    public IEnumerator OpenUpAndFly()
    {
        _mySound.Play("Pop");
        _upperBall.DOMoveY(transform.position.y + 3f, 0.8f).OnComplete(() => {
            _quote.DOFade(0, 0.5f);
            foreach (GameObject item in _birds)
            {
                //item.GetComponent<SpriteRenderer>().DOFade(1, 0.1f);
                item.SetActive(true);
            }
            foreach (SpriteRenderer rend in _spriteRenderers)
            {
                rend.DOFade(0, 0.5f);
            }
            foreach (GameObject item in _birds)
            {
                item.GetComponent<BirdBehaviour>().Fly();
            }
        });
        yield return new WaitForSeconds(1.2f);
        gameObject.SetActive(false);
    }
}
