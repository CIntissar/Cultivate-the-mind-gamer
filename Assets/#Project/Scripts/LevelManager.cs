using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelManager : MonoBehaviour
{
    public Transform treePainting;
    public float spritePositionY = 0f;
    public int punchVibration = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //using raycasts
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

        if(Input.GetMouseButtonDown(0))
        {
            if (hit2D.collider != null)
            {
                if (hit2D.collider.CompareTag("Apple"))
                {
                    //print("hey apple !");
                    GoToPainting();
                }
            }
            else
            {
                Debug.Log("there's nothing here...");
            }
        }
    }
    void GoToPainting()
    {
        // treePainting.DOMoveY(spritePositionY,1);
        // treePainting.DOPunchPosition(new Vector3(0,-10,0), 2, punchVibration, 0f);
        //use animation ??

        //temporary
        treePainting.DOMoveY(spritePositionY, 1).SetEase(Ease.OutBounce);
    }
}
