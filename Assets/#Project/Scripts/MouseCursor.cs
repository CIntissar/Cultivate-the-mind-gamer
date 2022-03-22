using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    [HideInInspector] public SpriteRenderer rend;
    public Sprite lensCursor;
    public Sprite normalCursor;

    void Start()
    {
        Cursor.visible = false; //hides the default cursor
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);

        //TEST
        if (Input.GetMouseButtonDown(0))
        {
            rend.sprite = lensCursor;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            rend.sprite = normalCursor;
        }
    }
}
