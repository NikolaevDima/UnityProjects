using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private Transform player;
    GameObject[] Enemy;
    private int mini = 0;
    private void Start()
    {
        StartCoroutine(Scele());
        StartCoroutine(die());
        player = GameObject.Find("Player").transform;
        Dist();
    }
    
    private void Dist()
    {
        float min = Mathf.Infinity;
        Enemy = GameObject.FindGameObjectsWithTag("En");
        try
        {
            if (Enemy.Length > 0)
            {
                for (int i = 0; i < Enemy.Length; i++)
                {
                    float distance = Vector3.Distance(player.transform.position, Enemy[i].transform.position);
                    if (distance < min)
                    {
                        mini = i;
                        min = distance;
                    }
                }
            }
        }
        catch
        {
            Dist();
        }
    } 

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;

        try
        {

            var direction = Enemy[mini].transform.position - transform.position;
            var angle = Mathf.Atan2(direction.y , direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle+90);
        }

        catch
        {
            Dist();
        }

    }



    IEnumerator Scele()
    {
        for (float q = 0.1f; q < 1f; q = q + 0.05f)
        {
            transform.localScale = new Vector3(q, q, q);
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator die()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
