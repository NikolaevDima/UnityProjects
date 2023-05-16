using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private GameObject num1;
    private GameObject num2;
    public Sprite[] numbers;
    //private GameObject player;

    void Start()
    {
        num1 = GameObject.Find("Num1");
        num2 = GameObject.Find("Num2");
    }

    public void LvlUp(int lvl)
    {
        num1.GetComponent<SpriteRenderer>().sprite = numbers[lvl / 10];
        num2.GetComponent<SpriteRenderer>().sprite = numbers[lvl % 10];
        LvlBoost();
    }

    public void LvlBoost()
    {
        Time.timeScale = 0f;
    }
}
