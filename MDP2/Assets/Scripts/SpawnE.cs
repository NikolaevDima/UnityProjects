using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnE : MonoBehaviour
{
    public bool be = false;
    public GameObject ePrefb;
    public GameObject e;
    public float scal;
    public GameObject panel;
    public ItemsController item;
    public bool inside = false;

    void Start()
    {
        panel = GameObject.Find("panel");
    }

    public void Update()
    {
        if ((inside) && (Time.timeScale != 0))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                tag = "ThisItem";
                Inventory num = panel.GetComponent<Inventory>();
                transform.localScale = new Vector2(scal, scal);
                num.Add();
                Ex();
                GetComponent<SpriteRenderer>().sortingOrder = panel.GetComponent<SpriteRenderer>().sortingOrder+1;
                try
                {
                    Destroy(GetComponent<MoveObject>());
                }
                catch
                {

                }
                Destroy(GetComponent<SpawnE>());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(ePrefb, transform.position, Quaternion.identity);
            inside = true;
        }
       
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Ex();
    }

    public void Ex()
    {
        inside = false;
        e = GameObject.Find("E(Clone)");
        Destroy(e);
    }
    
    public void Move(Vector2 startPosition, Vector2 finishPosition)
    {/*
        bool moveornot = true;
        if (moveornot) 
        {
            transform.position = finishPosition;
            moveornot = false;
        }
        else
        {
            transform.position = startPosition;
            moveornot = true;
        }
        */
    }

    
    }

