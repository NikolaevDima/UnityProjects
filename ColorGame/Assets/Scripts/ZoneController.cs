using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneController : MonoBehaviour
{
    public Sprite[] sp;
    public SpriteRenderer sr;
    public GameObject spawn;
    public float speed;
    public int r;
    public int rainbow;
    public bool hard = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        r = Random.Range(0, 3);
        rainbow = Random.Range(0, 9);
        sr.sprite = sp[r];
        spawn = GameObject.Find("Spawn");
        speed=spawn.GetComponent<SpwnZone>().speed;
        if ((rainbow == 0)&&(hard))
        {
            StartCoroutine(Flashing());
        }
    }

    void FixedUpdate()
    {
        transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
    }


    IEnumerator Flashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            r++;
            if (r == 3)
            {
                r = 0;
            }
            sr.sprite = sp[r];
        }
    }


}
