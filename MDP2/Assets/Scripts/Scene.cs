using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour
{
    public int j=0;
    public Sprite[] sprite = new Sprite[5];

    // Start is called before the first frame update
    void Start()
    {
       // GetComponent<SpriteRenderer>().sprite = sprite1;
    }

    public void LoadSprite(int j)
    {
        GetComponent<SpriteRenderer>().sprite = sprite[j];
    }
}
