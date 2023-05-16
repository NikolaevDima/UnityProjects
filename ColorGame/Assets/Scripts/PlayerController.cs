using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Sprite[] sp;
    public SpriteRenderer sr;
    public int i = 0;
    public bool life = true;
    public GameObject swap;
    public Animator anim;
    public GameObject score;
    public bool god = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        swap = GameObject.Find("Swap");
        score = GameObject.Find("Score");
        anim.enabled = false;
    }
    void Update()
    {
        if (life)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (i == 2)
                {
                    i = 0;
                }
                else
                {
                    i++;
                }
                sr.sprite = sp[i];
                swap.GetComponent<Swap>().Color_Swap(i);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    void OnMouseDown()
    {
        if (life == false)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (life)
        {
            if (other.gameObject.tag == "Zone")
            {

                if (other.gameObject.GetComponent<ZoneController>().r != i)
                {
                    if (god == false)
                    {
                        life = false;
                        anim.enabled = true;
                        anim.Play("Die");            
                    }
                }
                else
                {
                    score.GetComponent<ScoreController>().ScoreUp();
                }
            }
        }

    }
}
