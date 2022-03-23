using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    [HideInInspector] public SpriteRenderer rend;
    public Sprite magnifierCursor;
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
    }
    public void ChngeToMagnifier()
    {
        rend.sprite = magnifierCursor;
    }
    public void ChngeToDefault()
    {
        rend.sprite = normalCursor;
    }
}
