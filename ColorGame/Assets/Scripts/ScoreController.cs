using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public int score = 0;
    public Sprite[] sp;
    public SpriteRenderer sr;
    public GameObject dec;
    public GameObject hun;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        dec = GameObject.Find("Dec");
        hun = GameObject.Find("Hun");
    }

    public void ScoreUp()
    {
        score++;
        sr.sprite = sp[score % 10];
        dec.GetComponent<SpriteRenderer>().sprite = sp[(score / 10) % 10];
        hun.GetComponent<SpriteRenderer>().sprite = sp[(score / 100) % 10];
    }

}
