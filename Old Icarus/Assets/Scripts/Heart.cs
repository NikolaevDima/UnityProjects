using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(flashing());
    }

    IEnumerator flashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            transform.localScale = new Vector2(1.2f, 1.2f);
            yield return new WaitForSeconds(0.5f);
            transform.localScale = new Vector2(1f, 1f);
        }
    }
}
