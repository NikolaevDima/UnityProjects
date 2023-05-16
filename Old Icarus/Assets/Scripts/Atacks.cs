using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atacks : MonoBehaviour
{
    private Animator anim;
    public string anim_name;
    public GameObject player;
    private SpriteRenderer sr;
    private SpriteRenderer srp;
    private bool atackTime;
    public int dmg;

    void Start()
    {
        atackTime = false;
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        srp = player.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        anim.Play(anim_name);
        StartCoroutine(Dest());
        StartCoroutine(AtackT());
    }

    IEnumerator AtackT()
    {
        yield return new WaitForSeconds(0.625f);
        atackTime = true;
    }


    void Update()
    {

        if (srp.flipX)
        {
            sr.flipX = false;
            transform.position = player.transform.position - new Vector3(0.4f, 0f);
            sr.enabled = true;
        }
        else
        {
            sr.flipX = true;
            transform.position = player.transform.position + new Vector3(0.4f, 0f);
            sr.enabled = true;
        }

       
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Enemy")&&(atackTime))
        {
            Destroy(other.gameObject);
        }

    }

    IEnumerator Dest()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);

    }
}
