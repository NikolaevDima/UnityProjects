using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsController : MonoBehaviour
{
    public bool f = true;
    public string name;
    public float scal;
    public Inventory num;
    public GameObject panel;
    public SpawnE spawn;


    void Start()
    {
        spawn = GetComponent<SpawnE>();
    }

    void Update()
    {

       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //inside = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
       // inside = false;
    }
}

