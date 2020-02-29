using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleMovements : MonoBehaviour
{
    [Range(0f, 100f)]
    public float speed;
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += Vector3.down * speed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += Vector3.right * speed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.Z))
        {
            this.transform.position += Vector3.up * speed * Time.deltaTime;

        }
    }
}
