using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UsingController : MonoBehaviour
{
    public bool optim = true;
    public bool f = true;
    public GameObject ePrefb;
    public GameObject e;
    public bool inside = false;
    public int step;
    public Inventory invent;
    public string name;
    public GameObject item1;
    public GameObject item2;
    public GameObject panel;
    public GameObject room; 
    public Scene scene;
    public GameObject pc;
    public Pc pcScript;

    void Start()
    {
        panel = GameObject.Find("panel");
        room = GameObject.Find("room");
        pc = GameObject.Find("pc");
        scene = room.GetComponent<Scene>();
        pcScript=pc.GetComponent<Pc>();
    }


    public void Update()
    {
        if ((inside) && (Time.timeScale != 0))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (step == 3)
                {
                    SceneManager.LoadScene(2);
                }

                invent = panel.GetComponent<Inventory>();
                if (step == 0)
                {
                    for (int i = 0; i < invent.num; i++)
                    {
                        
                        if (invent.Items[i] == item1)
                        {
                            if (f)
                            {
                                step++;
                                scene.LoadSprite(step);
                                f = false;                           
                            }
                           
                            invent.Sort(invent.Items[i]);
                            //оно сломалоооось((
                        }
                        
                    }
                    
                }
                
                if ((step == 1)&&(f))
                {            
                    pcScript.Task();
                }

                if (step == 2)
                {
                    for (int i = 0; i < invent.num; i++)
                    {

                        if (invent.Items[i] == item2)
                        {
                            if (f)
                            {
                                step++;
                                scene.LoadSprite(step);
                                f = false;
                            }

                            invent.Sort(invent.Items[i]);
                            //оно сломалоооось((
                        }
                    }
                }

            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                if (item1 == null)
                {
                    f = true;
                }
            }
        }
        if ((step == 2)&&(optim))
        {
            optim = false;
            scene.LoadSprite(step);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(ePrefb, transform.position, Quaternion.identity);
        }
        inside = true;
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