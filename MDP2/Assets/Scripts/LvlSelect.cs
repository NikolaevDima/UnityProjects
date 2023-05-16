using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlSelect : MonoBehaviour
{
    public Sprite[] sp;
    public int lvl = 1;

    public void LvlRef()
    {
        lvl++;
        if (lvl == sp.Length+1)
        {
            lvl = 1;
        }
        GetComponent<SpriteRenderer>().sprite = sp[lvl-1];
    }
}