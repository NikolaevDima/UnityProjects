using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agr : MonoBehaviour
{
    public bool f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            f = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            f = false;
        }
    }
}
