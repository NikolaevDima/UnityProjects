using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed;
    private Animator anim;
    private SpriteRenderer sr;

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
       
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
        if (horizontinput < 0)
        {
            sr.flipX = false;
        }
        if (horizontinput > 0)
        {
            sr.flipX = true;
        }
        if ((horizontinput == 0) && (vertinput == 0))
        {
            anim.Play("Idle");
        }
        else
        {
            anim.Play("Move");
        }
        transform.Translate(Vector2.right * Time.deltaTime * speed * horizontinput);
        transform.Translate(Vector2.up * Time.deltaTime * speed * vertinput);      
    }   
}
