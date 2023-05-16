using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject[] Enemy;
    private int mini = 0;
    // Start is called before the first frame update
    void Start()
    {
        float min = Mathf.Infinity;
        Enemy = GameObject.FindGameObjectsWithTag("En");
        try
        {

            if (Enemy.Length > 0)
            {
                for (int i = 0; i < Enemy.Length; i++)
                {
                    float distance = Vector3.Distance(transform.position, Enemy[i].transform.position);
                    if (distance < min)
                    {
                        mini = i;
                        min = distance;
                    }
                }
            }
            else
            {
                Destroy(gameObject);
            }

        }
        catch
        {


        }
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (Enemy.Length > 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, Enemy[mini].transform.position, 0.5f);
            }
        }
        catch
        {
            Destroy(gameObject);
        }
    }

}
