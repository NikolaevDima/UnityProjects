using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour
{
    public float dis;


    void OnTriggerStay2D(Collider2D other)
    {
        try
        {
            if (other.tag != "Button")
            {
                dis = transform.position.y - other.transform.position.y;
                other.GetComponent<SpriteRenderer>().sortingOrder = System.Convert.ToInt32(dis / 0.01);
            }
        }
        catch
        {

        }

    }
}
