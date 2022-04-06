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
    int index = 0;

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
                        StartCoroutine(CloseCurtains());
                    }
                    else
                    {
                        //sound : bounce
                        FindObjectOfType<AudioManager>().Play("PaintingFall");
                        treePainting.DOMoveY(spritePositionY, 1).SetEase(paintingEaseType);
                    }
                }
                
                if(hit2D.collider.CompareTag("Hatches"))
                {
                    for (int i = 0; i < hatches.Count; i++) //pour chaque portes
                    {
                        if(hit2D.collider.gameObject == hatches[i].gameObject && hatches[i].GetComponent<HatchesBehaviour>().canMove)
                        {
                            sprites[index].position = hatches[i].position;
                            FindObjectOfType<AudioManager>().Play("Open");
                            hatches[i].DOMoveX(4,1);
                            hatches[i].GetComponent<HatchesBehaviour>().canMove = false;
                            index++;
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
            FindObjectOfType<AudioManager>().Play("AppleClicked");
            sprites[i].transform.DOScale(Vector3.zero, 0.4f);
        }
        yield return new WaitForSeconds(0.8f);
        treePainting.DOMoveY(10.75f,1);
    }
    IEnumerator CloseCurtains()
    {
        //sound : curtains
        FindObjectOfType<AudioManager>().Play("CurtainsClose");
        rightCurtain.DOMoveX(3, 0.7f);
        leftCurtain.DOMoveX(-3, 0.9f);
        yield return new WaitForSeconds(1.7f);
        SceneManager.LoadScene("EndScene");
    }
}
