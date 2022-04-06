using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return : MonoBehaviour
{
    // Make the clouds go back where it started
    public float cloudSpeed = 0.05f;
    private void Update() 
    {
        transform.Translate(cloudSpeed * Time.deltaTime, 0, 0);

        if(transform.position.x >= 30f)
        {
            transform.position = new Vector3(-30,transform.position.y,transform.position.z);
        }

    }
}