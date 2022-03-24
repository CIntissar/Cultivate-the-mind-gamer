using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    [HideInInspector] public SpriteRenderer rend;
    public Sprite magnifierCursor;
    public Sprite normalCursor;
    Ray ray;

    void Start()
    {
        Cursor.visible = false; //hides the default cursor
        rend = GetComponent<SpriteRenderer>();
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics2D.Raycast(ray.origin, ray.direction))
        {
            rend.sprite = magnifierCursor;
        }
        else
        {
            rend.sprite = normalCursor;
        }
    }
}
