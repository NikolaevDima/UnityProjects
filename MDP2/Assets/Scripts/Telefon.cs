using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telefon : MonoBehaviour
{

    public GameObject panel;
    public GameObject item;
    public bool f = false;
    public bool inside = false;
    public GameObject ePrefb;
    public GameObject e;
    public Inventory invent;

    void Start()
    {
        panel = GameObject.Find("panel");

    }

    void Update()
    {
        if ((inside) && (Time.timeScale != 0) && (f))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                for (int i = 0; i < invent.num; i++)
                {

                    if (invent.Items[i] == item)
                    {
                        invent.Sort(invent.Items[i]);
                        f = false;
                        Ex();
                    }
                }
            }
        }
        invent = panel.GetComponent<Inventory>();
        for (int i = 0; i < invent.num; i++)
        {

            if (invent.Items[i] == item)
            {
                f = true;
            }
        }

    }




    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Player") && (f))
        {
            Instantiate(ePrefb, transform.position, Quaternion.identity);
        }
        inside = true;
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
}
