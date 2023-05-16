using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RozetkfOff : MonoBehaviour
{
    public GameObject room;
    public bool inside = false;
    public GameObject ePrefb;
    public GameObject e;
    public Sprite sp;
    public bool f = true;

    void Start()
    {
      room = GameObject.Find("2room");
    }

    // Update is called once per frame
    void Update()
    {
        if ((inside) && (Time.timeScale != 0) && (f))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                f = false;
                room.GetComponent<SpriteRenderer>().sprite = sp;
                Ex();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Player")&&(f))
        {
            Instantiate(ePrefb, transform.position + new Vector3(0f, 0.9f,0f), Quaternion.identity);
            inside = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Ex();
    }

    public void Ex()
    {
        inside = false;
        e = GameObject.Find("E(Clone)");
        Destroy(e);
    }
}
