using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class Controller : MonoBehaviour
{
    public float speed = 6f;
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public bool life;
    public GameObject aoePrefabs;
    public GameObject bulletPrefabs;
    public GameObject firePrefabs;
    public GameObject cam;
    public float dmg = 10f;
    public bool god = false;
    public int kills = 0;
    public float xp = 100f;
    public int lvl=1;
    public float hp = 100f;
    public float maxhp = 100f;
    public float critdmg = 1.5f;
    public float critchance;
    public TextMeshProUGUI text;

    public void Kill()
    {
        kills++;
        if (kills * 10 >= xp)
        {
            xp = 2*xp + lvl * 10;
            Lvl();

        }
        info();
    }

    public void Lvl()
    {
        lvl++;
        dmg = dmg * 1.1f;
        maxhp = maxhp * 1.05f;
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dmg = 10f;
        life = true;
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(0, 0, 0);
        cam = GameObject.Find("Main Camera");
        text = FindObjectOfType<TextMeshProUGUI>();
        info();
        StartCoroutine(cloneAoe());
        StartCoroutine(cloneBullet());
        StartCoroutine(cloneFire());
        StartCoroutine(regeneration());
    }

    private void Update()
    {
        if (life)
        {
            Move();
        }
    }

    private void Move()
    {
        float horizontinput = Input.GetAxis("Horizontal");
        float vertinput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontinput);
        transform.Translate(Vector3.up * Time.deltaTime * speed * vertinput);
        
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (god==false)
        {
            if (other.gameObject.tag == "En")
            {
                hp = hp - 10;
                info();
                if (hp <= 0)
                {
                    life = false;
                    StartCoroutine(die());
                }
            }
        }
    }

    IEnumerator cloneBullet()
    {
        while(life)
        {
            Instantiate(bulletPrefabs, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1.5f);
        }
    }

    IEnumerator cloneAoe()
    {
        while (life)
        {
            Instantiate(aoePrefabs, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator cloneFire()
    {
        while (life)
        {
            Instantiate(firePrefabs, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
    }

    IEnumerator regeneration()
    {
        while (life)
        {
            yield return new WaitForSeconds(1f);
            if (hp < maxhp)
            {
                hp = hp + 1f;
                info();
            }
        }
    }

    public void info()
    {
        text.text = "Здоровье: " + System.Convert.ToString(hp) + "\n" + "Уровень: " + System.Convert.ToString(lvl) + "\n" + "Урон: " + System.Convert.ToString(dmg) + "\n" + "Убийства: " + System.Convert.ToString(kills);
    }

    IEnumerator die()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
