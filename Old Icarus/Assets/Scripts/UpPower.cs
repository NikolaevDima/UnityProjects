using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpPower : MonoBehaviour
{
    public int posholnahuy = 0;

    void OnMouseEnter()
    {
        transform.localScale = new Vector2(1.1f, 1.1f);

    }

    void OnMouseExit()
    {
        transform.localScale = new Vector2(1f, 1f);
    }

    void OnMouseUp()
    {
        posholnahuy++;
    }
}
