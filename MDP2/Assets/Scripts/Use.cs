using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Use : MonoBehaviour
{
    void Start()
    {
        transform.position += new Vector3(0, 0.5f);
        StartCoroutine(flashing());
    }

    void Update()
    {

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
