using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Transform treePainting;
    [SerializeField] float spritePositionY = -0.05f;
    [SerializeField] Ease paintingEaseType = Ease.OutBounce;
    [SerializeField] GameObject shadowApple; //shadow apple
    [SerializeField] List<Transform> hatches = new List<Transform>();
    [SerializeField] List<Transform> sprites = new List<Transform>();
    [SerializeField] GameObject greenApple;
    AppleBehaviour appleBehaviour;
    [SerializeField] Transform leftCurtain;
    [SerializeField] Transform rightCurtain;
    [SerializeField] Ease curtainEaseType;
    bool startLoop = true;

    void Start()
    {
        appleBehaviour = shadowApple.GetComponent<AppleBehaviour>();
    }
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

        if(Input.GetMouseButtonDown(0))
        {
            if (hit2D.collider != null)
            {
                if (hit2D.collider.CompareTag("Apple"))
                {
                    if(appleBehaviour.spriteChanged)
                    {
                        //SceneManager.LoadScene("EndScene");
                        CloseCurtains();
                    }
                    else
                    {
                        //sound : bounce
                        treePainting.DOMoveY(spritePositionY, 1).SetEase(paintingEaseType);
                    }
                }
                
                if(hit2D.collider.CompareTag("Hatches"))
                {
                    startLoop = true;
                    for (int i = 0; i < hatches.Count; i++)
                    {
                        if(startLoop)
                        {
                            if(hit2D.collider.gameObject == hatches[i].gameObject && hatches[i].GetComponent<HatchesBehaviour>().canMove)
                            {
                                for (int j = 0; j < sprites.Count; j++)
                                {
                                    if(i==j)
                                    {
                                        sprites[j].position = hatches[i].position;
                                        //sound : open
                                        hatches[i].DOMoveX(4,1);
                                        hatches[i].GetComponent<HatchesBehaviour>().canMove = false;
                                    }
                                }
                                startLoop = false;
                            }
                        }
                    }
                }
                if (hit2D.collider.CompareTag("GreenApple"))
                {
                    appleBehaviour.ChangeSprite();
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
        for (int i = 0; i < sprites.Count; i++)
        {
            //sound : scale down
            sprites[i].transform.DOScale(Vector3.zero, 0.4f);
        }
        yield return new WaitForSeconds(0.8f);
        treePainting.DOMoveY(10.75f,1);
    }
    void CloseCurtains()
    {
        //sound : curtains
        rightCurtain.DOMoveX(1, 0.8f);
        leftCurtain.DOMoveX(-3, 1);
    }
}
