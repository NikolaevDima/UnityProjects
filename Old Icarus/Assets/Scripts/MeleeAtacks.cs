using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAtacks : MonoBehaviour
{
    public GameObject player;
    private SpriteRenderer srp;
    private bool atackTime;
    public int dmg;

    void Start()
    {
        atackTime = false;
        player = GameObject.Find("Player");
        srp = player.GetComponent<SpriteRenderer>();
        StartCoroutine(Dest());
    }



    void Update()
    {

        if (srp.flipX)
        {
            transform.position = player.transform.position - new Vector3(0.4f, 0f);
        }
        else
        {
            transform.position = player.transform.position + new Vector3(0.4f, 0f);
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //&& (atackTime)
        if ((other.gameObject.tag == "Enemy") )
        {
            other.GetComponent<EnemyController>().Pain(dmg);
            //Destroy(other.gameObject);
        }

    }

    IEnumerator Dest()
    {
        yield return new WaitForSeconds(0.15f);
        Destroy(gameObject);

    }
}
