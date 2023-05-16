using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool cd = true;
    private bool receiveDmg = true;
    private bool receiveTime = true; 
    public float speed;
    private Animator anim;
    private SpriteRenderer sr;
    private GameObject health;
    public float xp = 0f;
    public float maxXp = 100f;
    private GameObject xpPanel;
    public float hp = 100f;
    public float maxHp = 100f;
    private bool life = true;
    public GameObject heart;
    public SpriteRenderer spriteHeart;
    public Sprite newheart;
    public GameObject veapon;
    public string debil;
    private float preAtack = 1f;
    private float posAtack = 1f;
    public int lvl = 1;
    public GameObject level;

    void Start()
    {
        health = GameObject.Find("Health");
        heart = GameObject.Find("Heart");
        xpPanel = GameObject.Find("XpPanel");
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        spriteHeart=heart.GetComponent<SpriteRenderer>();
        level = GameObject.Find("Lvl");
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E))&&(cd))
        {
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        cd = false;
        
        if (veapon.name == "666")
        {
            preAtack = 0.3f;
            posAtack = 0.7f;
        }
        if(veapon.name=="stick")
        {
            anim.Play("Attacks");
            preAtack = 0.33f;
            posAtack = 0.14f;
        }

        yield return new WaitForSeconds(preAtack);
        Instantiate(veapon, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(posAtack);
        cd = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            receiveDmg = false;
        }
    }

    public void XpPanel(float enemyXp)
    {
        xp += enemyXp;
        if (xp < maxXp)
        {
            xpPanel.transform.localScale = new Vector2(xp / maxXp, 1f);
        }
        else
        {
           // xpPanel.transform.localScale = new Vector2(0f, 1f);
            lvl++;
            xp -= maxXp;
            maxXp += 10;
            xpPanel.transform.localScale = new Vector2(xp / maxXp, 1f);
            level.GetComponent<LevelController>().LvlUp(lvl);
        }
    }

    private void HealthPanel(float enemyDmg)
    {
        if (life)
        {
            health.transform.localScale = new Vector2(hp / maxHp, 1f);
            health.transform.position -= new Vector3(enemyDmg / 200f, 0f);
        }
        else
        {
            health.transform.localScale = new Vector2(0f, 0f);
            spriteHeart.sprite = newheart;
        }
    }


    public void Pain(float enemyDmg)
    {
        receiveTime = false;
        hp -= enemyDmg;
        if (hp <= 0)
        {
            Die();
        }
        HealthPanel(enemyDmg);
        receiveTime = true;
    }
    
    public void Die()
    {
        life = false;
    }

    void FixedUpdate()
    {
        if (life)
        {
            Move();
        }
    }

    void Move()
    {

        float horizontinput = Input.GetAxis("Horizontal");
        float vertinput = Input.GetAxis("Vertical");
        if (horizontinput < 0)
        {
            sr.flipX = true;
        }
        if (horizontinput > 0)
        {
            sr.flipX = false;
        }
        if ((horizontinput == 0) && (vertinput == 0) && (cd))
        {
            anim.Play("Idle");
        }
        else
        {
            if (cd)
            {
                anim.Play("Move");
            }
        }
        transform.Translate(Vector2.right * Time.deltaTime * speed * horizontinput);
        transform.Translate(Vector2.up * Time.deltaTime * speed * vertinput);

    }
}