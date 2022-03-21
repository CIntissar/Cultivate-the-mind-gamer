using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    public GameObject cursor1;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false; //hides the default cursor
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursor1.transform.position = cursorPos;
    }
}
