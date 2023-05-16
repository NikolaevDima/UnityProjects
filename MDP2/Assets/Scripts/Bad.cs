using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bad : MonoBehaviour
{
    public bool f = true;
    public bool inside = false;
    public int bad = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inside)
        {
            if ((Input.GetKey(KeyCode.E)) && (f))
            {
                f = false;
                bad++;
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                f = true;
            }
        }
        if (bad >=666)
        {
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        inside = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        inside = false;
    }
}