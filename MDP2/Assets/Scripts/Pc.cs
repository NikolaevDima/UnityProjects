using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pc : MonoBehaviour
{
    public SpriteRenderer sr;
    public GameObject[] p;
    public GameObject pc;
    public UsingController uc;
    public int fin = 0;

    void Start()
    {

        sr = GetComponent<SpriteRenderer>();
        p = GameObject.FindGameObjectsWithTag("Wire");
        pc = GameObject.Find("PC");
        uc = pc.GetComponent<UsingController>();
    }

    public void Task()
    {
       sr.enabled = true;
       for(int i = 0; i < p.Length; i++)
       {
            p[i].GetComponent<Collider2D>().enabled = true;
            p[i].GetComponent<SpriteRenderer>().enabled=true;
       }
    }

    public void Finish()
    {
        fin++;
        if (fin == 5)
        {
            StartCoroutine(end());
        }
    }

    IEnumerator end()
    {
        yield return new WaitForSeconds(1f);
        uc.step++;
        for (int i = 0; i < p.Length; i++)
        {
            p[i].SetActive(false);
        }
        sr.enabled = false;
    }
}
