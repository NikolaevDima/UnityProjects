using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyController : MonoBehaviour
{
    private float speed = 3f;
    public Rigidbody2D rb;
    private GameObject player;
    public float hp;
    private float dmg;
    private Controller con;
    private TextMeshProUGUI text;
    private float ratio;
    private GameObject spawn;
    private SpawnEnemy scon;


    void Start()
    {
        spawn = GameObject.Find("Spawn");
        SpawnEnemy scon = spawn.GetComponent<SpawnEnemy>();
        hp = scon.hp;
        text = FindObjectOfType<TextMeshProUGUI>();
        player = GameObject.Find("Player");
        text.text = System.Convert.ToString(hp);

    }

    void Update()
    {
        Move();
    }
    
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "At")
        {
            ratio = 2;
            Pain();
        }
        if (other.gameObject.tag == "Bu")
        {
            ratio = 1;
            Pain();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Fi")
        {
            ratio = 0.1f;
            StartCoroutine(pain());
        }
    }

    private void Pain()
    {
        Controller con = player.GetComponent<Controller>();
        hp = hp - con.dmg * ratio;
        if (hp <= 0)
        {
            con.Kill();
            Destroy(gameObject);
        }
        text.text = string.Format("{0:#.0}",hp);
    }


    IEnumerator pain()
    {
        for (int i = 0; i < 9; i++)
        {
            ratio = 0.1f;
            Pain();
            yield return new WaitForSeconds(0.5f);
        }

    }


}
