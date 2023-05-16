using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseController : MonoBehaviour
{
    public bool inside = false;

    void Update()
    {
        if ((Input.GetKey(KeyCode.E))&&(inside))
        {
            Closer();
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

    public void Closer()
    {
        transform.position = new Vector2(0, -5);
    }


}
