using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool f = false;
    public SpawnE item;
    public int num = 0;
    public GameObject[] Items = new GameObject[12];
    public GameObject del;

    public void Add()
    {
        Items = GameObject.FindGameObjectsWithTag("ThisItem");
        Items[num].transform.position = new Vector2(-2.9f + num * 0.525f, -1.7f);
        num++;
    }

    public void Sort(GameObject del)
    {
        //Destroy(del);

        for (int i = 0; i < num; i++)
        {
            if (Items[i] == del)
            {
                Destroy(Items[i]);
                Items[i] = null;
            }
                if ((Items[i] == null)&&(num>1)&&(i!=num-1))
                {
                    Items[i] = Items[i + 1];
                    Items[i + 1] = null;
                    Items[i].transform.position = new Vector2(-2.9f + i * 0.525f, -1.7f);
                    f = true;//безполезногиня

                }
            
        }
        num--;

    } 
}
