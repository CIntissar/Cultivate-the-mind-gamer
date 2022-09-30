using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseCursor : MonoBehaviour
{
    SpriteRenderer _rend;
    [SerializeField] Sprite _magnifierCursor;
    [SerializeField] Sprite _normalCursor;
    Ray _ray;
    [SerializeField] float _positionOffSetY = 9f;
    void Awake()
    {
        Cursor.visible = false;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        _rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = cursorPos;

        if(SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("Dot on sea"))
        {
            transform.position = new Vector2(cursorPos.x, cursorPos.y + _positionOffSetY);
        }
        else
        {
            transform.position = cursorPos;
        }

        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics2D.Raycast(_ray.origin, _ray.direction))
        {
            _rend.sprite = _magnifierCursor;
        }
        else
        {
            _rend.sprite = _normalCursor;
        }
    }
}
