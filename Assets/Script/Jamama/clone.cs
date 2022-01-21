using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clone : MonoBehaviour
{
    private float speed = 10f;
    private Vector3 moveDirection = Vector3.zero;
    private void Start()
    {
        
    }
    private void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal_Ja"), 0.0f, 0.0f);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection = moveDirection * speed;

    }

}
