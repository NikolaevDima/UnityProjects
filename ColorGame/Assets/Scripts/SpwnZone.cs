using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwnZone : MonoBehaviour
{
    public GameObject ZonePrefab;
    public float speed = 0.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        speed *= 1.01f;
        Instantiate(ZonePrefab, transform.position + new Vector3(1f, 0, 0), Quaternion.identity);
    }
}
