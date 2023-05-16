using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public float speed;

    void Start()
    {

    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float horizontinput = Input.GetAxis("Horizontal");
        float vertinput = Input.GetAxis("Vertical");
        transform.Translate(Vector2.right * Time.deltaTime * speed * horizontinput);
        transform.Translate(Vector2.up * Time.deltaTime * speed * vertinput);
    }

}