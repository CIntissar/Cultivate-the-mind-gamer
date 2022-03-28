using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return : MonoBehaviour
{
    // Make the clouds go back where it started
    private void Update() 
    {
        transform.Translate(0.01f, 0, 0);

        if(transform.position.x >= 30f)
        {
            transform.position = new Vector3(-30,transform.position.y,transform.position.z);
        }

    }
}