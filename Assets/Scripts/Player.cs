using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    void Update()
    {
        Vector3 delta = Vector3.zero; //delta = movement
        if(Input.GetKey(KeyCode.W))
        {
            delta.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            delta.y -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            delta.x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            delta.x += 1;
        }

        transform.position += delta.normalized * speed * Time.deltaTime;

    }
}