using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    public GameObject maker;
    private SpriteRenderer srp;
    private bool atackTime;
    public int dmg;

    void Start()
    {
        atackTime = false;
        StartCoroutine(Dest());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //&& (atackTime)
        if ((other.gameObject.tag == "Player"))
        {
            other.GetComponent<PlayerController>().Pain(dmg);
            //Destroy(other.gameObject);
        }

    }

    IEnumerator Dest()
    {
        yield return new WaitForSeconds(0.15f);
        Destroy(gameObject);

    }
}
