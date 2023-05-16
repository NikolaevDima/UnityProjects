using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spase : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(flashing());
    }

    IEnumerator flashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            transform.localScale = new Vector2(0.6f, 0.6f);
            yield return new WaitForSeconds(0.5f);
            transform.localScale = new Vector2(0.5f, 0.5f);
        }
    }
}
