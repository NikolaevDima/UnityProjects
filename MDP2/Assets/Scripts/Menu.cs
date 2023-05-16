using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Menu : MonoBehaviour
{
    public bool puse = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (puse)
            {
                Time.timeScale = 1f;
                puse = false;
                transform.position += new Vector3(0, -5.5f);
            }
            else 
            {
                Time.timeScale = 0f;
                puse = true;
                transform.position += new Vector3(0, 5.5f);
            }
        }
    }

}
