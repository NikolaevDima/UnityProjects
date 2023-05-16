using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aoe : MonoBehaviour
{
    private Transform player;

    private void Start()
    {
        StartCoroutine(Scele());
        StartCoroutine(die());
        player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        transform.position = player.transform.position;
    }

    IEnumerator Scele()
    {
        for (float q=1f; q < 6f; q=q+0.5f)
        {
            transform.localScale = new Vector3(q, q, q);
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator die()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
