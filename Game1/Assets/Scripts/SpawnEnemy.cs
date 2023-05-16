using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefabs;
    private GameObject player;
    private float rate = 5f;
    public float hp = 50;

    void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(cloneEnemyPrefab());
        StartCoroutine(hpEnemyPrefab());
    }

    IEnumerator cloneEnemyPrefab()
    {

        while (true)
        {
            System.Random rndp = new System.Random();
            int p = rndp.Next(0, 4);
            System.Random rndx = new System.Random();
            float x = rndx.Next(10, 12);
            System.Random rndy = new System.Random();
            float y = rndy.Next(10, 12);
            int px = 1;
            int py = 1;
            x = x + player.transform.position.x;
            y = y + player.transform.position.y;
            switch (p)
            {
                case (1):
                    py = -1;
                    break;
                case (2):
                    px = -1;
                    py = -1;
                    break;
                case (3):
                    px = -1;
                    break;
            }


            Instantiate(enemyPrefabs, new Vector3(x * px,  y * py, 0), Quaternion.identity);
            yield return new WaitForSeconds(rate);
            if (rate > 1f)
            {
                rate = rate * 0.9f; 
            }
        }
    }
    IEnumerator hpEnemyPrefab()
    {
        while (true)
        {
            yield return new WaitForSeconds(20f);
            hp = hp * 1.1f;
        }
    }

}
