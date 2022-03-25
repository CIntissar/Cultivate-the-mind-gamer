using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseCursor : MonoBehaviour
{
    [HideInInspector] public SpriteRenderer rend;
    public Sprite magnifierCursor;
    public Sprite normalCursor;
    Ray ray;
    public float positionOffSetY = 9f;
    void Awake()
    {
        Cursor.visible = false;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Dot on sea"))
        {
            transform.position = new Vector2(cursorPos.x, cursorPos.y + positionOffSetY);
        }
        else
        {
            transform.position = cursorPos;
        }

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
