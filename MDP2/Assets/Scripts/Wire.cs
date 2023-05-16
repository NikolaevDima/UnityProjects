using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public bool use = true;
    public float x;
    public float y;
    public float xTrue;
    public float yTrue;
    public SpriteRenderer sr;
    public Rigidbody2D rb;
    public Vector2 pos;
    private Vector3 offset;
    public Sprite sprite;
    public GameObject pc;
    public Pc pcs;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        pos = new Vector2(xTrue, yTrue);
        pc = GameObject.Find("pc");
        pcs = pc.GetComponent<Pc>();
    }

   
    void Update()
    {
        
        if (Vector2.Distance(transform.position, pos)<=0.1)
        {
            if (use)
            {
                pcs.Finish();
            }
            use = false;
            transform.position = pos;
            sr.sprite = sprite;
            GetComponent<Collider2D>().enabled = false;

        }
    }

    void OnMouseDown()
    {
        if (use)
        {
            offset = gameObject.transform.position -
                Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        }
    }

    void OnMouseDrag()
    {
        if (use)
        {
            Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
            transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
        }
    }

    void OnMouseUp()
    {

        if (use)
        {
            transform.position = new Vector2(x, y);
        }
    }



}
