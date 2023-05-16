using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private bool cd = true;
    public GameObject player;
    public float speed;
    private Animator anim;
    private SpriteRenderer sr;
    public int EnemyDmg;
    public GameObject agr;
    public Agr agrScript;
    public float hp;
    public GameObject health;
    private float maxHp;
    public string IdleAniation;
    public string MoveAnimation;
    public string AttacksAnimation;
    public GameObject attack;
    private bool collPlayer = false;
    public float xp;
   // private PlayerController playerScript;

    void Start()
    {
        maxHp = hp;
        agr = this.transform.Find("AgrZone").gameObject;
        health = this.transform.Find("EnemyHealth").gameObject;
        agrScript = agr.GetComponent<Agr>();
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        anim.Play(IdleAniation);
    } 

    void Update()
    {

    }
    
    void FixedUpdate()
    {
        if ((agrScript.f) && (cd))
        {
            Move();

        }
        else
        {
            if (cd)
            {
                anim.Play(IdleAniation);
            }
        }
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        if (speed > 0f)
        {
            anim.Play(MoveAnimation);

            if (player.transform.position.x > transform.position.x)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }
        }
    }



    public void Pain(int playerDmg)
    {
        
        hp -= playerDmg;
        health.transform.localScale = new Vector2((hp/maxHp)/2f, 0.1f);
        if (hp <= 0)
        {
            player.GetComponent<PlayerController>().XpPanel(xp);

            Destroy(gameObject);
        }
        transform.position += transform.position - player.transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collPlayer = true;
            StartCoroutine(Cooldown());
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {         
            collPlayer = false;
            speed = 1.5f;
        }
    }

    IEnumerator Cooldown()
    {
        while (collPlayer)
        {
            speed = 0f;
            cd = false;
            anim.Play(AttacksAnimation);
            yield return new WaitForSeconds(0.666f);
            Instantiate(attack, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.334f);
            cd = true;
        }
    }

}
