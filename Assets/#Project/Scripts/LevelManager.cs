using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Transform _treePainting;
    [SerializeField] float _spritePositionY = -0.05f;
    [SerializeField] Ease _paintingEaseType = Ease.OutBounce;
    [SerializeField] GameObject _shadowApple; //shadow apple
    [SerializeField] List<Transform> _hatches = new List<Transform>();
    [SerializeField] List<Transform> _sprites = new List<Transform>();
    [SerializeField] SpriteRenderer _whiteQuote;
    [SerializeField] SpriteRenderer _blackQuote;
    [SerializeField] GameObject _greenApple;
    AppleBehaviour _appleBehaviour;
    [SerializeField] Transform _leftCurtain;
    [SerializeField] Transform _rightCurtain;
    [SerializeField] Ease _curtainEaseType;
    int _index = 0;
    AudioManager _mySound;

    void Awake()
    {
        _mySound = FindObjectOfType<AudioManager>();
    }
    void Start()
    {
        print("Stopping beach ambiance now");
        _mySound.StopPlaying("BeachAmbiance");
        print("beach ambiance stopped !");
        _mySound.Play("MountainAmbiance");
        _appleBehaviour = _shadowApple.GetComponent<AppleBehaviour>();
    }
    void Update()
    {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D _hit2D = Physics2D.GetRayIntersection(_ray);

        if(Input.GetMouseButtonDown(0))
        {
            if (_hit2D.collider != null)
            {
                if (_hit2D.collider.CompareTag("Apple"))
                {
                    if(_appleBehaviour.spriteChanged)
                    {
                        StartCoroutine(CloseCurtains());
                    }
                    else
                    {
                        _mySound.Play("PaintingFall");
                        _treePainting.DOMoveY(_spritePositionY, 1).SetEase(_paintingEaseType);
                    }
                }
                
                if(_hit2D.collider.CompareTag("Hatches"))
                {
                    for (int i = 0; i < _hatches.Count; i++) //pour chaque portes
                    {
                        if(_hit2D.collider.gameObject == _hatches[i].gameObject && _hatches[i].GetComponent<HatchesBehaviour>().canMove)
                        {
                            _sprites[_index].position = _hatches[i].position;
                            _mySound.Play("Open");
                            _hatches[i].DOMoveX(4,1);
                            _hatches[i].GetComponent<HatchesBehaviour>().canMove = false;
                            if(_index==0)
                            {
                                _whiteQuote.DOFade(0.854902f, 0.5f);
                            }
                            else if(_index==1)
                            {
                                _blackQuote.DOFade(0.854902f, 0.5f);
                            }
                            _index++;
                        }
                    }
                }
                if (_hit2D.collider.CompareTag("GreenApple"))
                {
                    _appleBehaviour.ChangeSprite();
                    StartCoroutine(ScaleDown());
                }
            }
            else
            {
                Debug.Log("there's nothing here...");
            }
        }
    }
    public IEnumerator ScaleDown()
    {
        for (int i = 0; i < _sprites.Count; i++)
        {
            _mySound.Play("AppleClicked");
            _sprites[i].transform.DOScale(Vector3.zero, 0.4f);
        }
        yield return new WaitForSeconds(0.8f);
        _treePainting.DOMoveY(10.75f,1);
    }
    IEnumerator CloseCurtains()
    {
        _mySound.Play("CurtainsClose");
        _rightCurtain.DOMoveX(3, 0.7f);
        _leftCurtain.DOMoveX(-3, 0.9f);
        yield return new WaitForSeconds(1.7f);
        SceneManager.LoadScene("EndScene");
    }
}
