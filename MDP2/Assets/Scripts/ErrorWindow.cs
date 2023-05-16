using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorWindow : MonoBehaviour
{
    public bool inside = false;
    public GameObject Window;
    public GameObject[] Winds;

    void Start()
    {
        Winds = GameObject.FindGameObjectsWithTag("Wind");
    }

    void Update()
    {
        if ((Input.GetKeyUp(KeyCode.E)) && (inside))
        {
            for (int i = 0; i < Winds.Length; i++)
            {
                Winds[i].GetComponent<CloseController>().Closer();
            }
            Window.transform.position = new Vector2(0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        inside = true;
        transform.localScale = new Vector2(2.2f, 2.2f);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        inside = false;
        transform.localScale = new Vector2(2f, 2f);
    }

}
