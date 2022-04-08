using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class TestScirpt : MonoBehaviour // IPointerClickHandler
{
    public int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        count++;
    }

    // Update is called once per frame
    void Update()
    {
        print(count);
    }
}
