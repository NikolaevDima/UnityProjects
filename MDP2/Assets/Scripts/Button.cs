using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public int scene;
    public int restart;
    public string tipe;
    public GameObject lvlScore;

    public void Start()
    {
        Time.timeScale = 1f;
    }

    void OnMouseEnter()
    {
        transform.localScale = new Vector2(1.1f, 1.1f);

    }

    void OnMouseExit()
    {
        transform.localScale = new Vector2(1f, 1f);
    }

    public void OnMouseDown()
    {
        switch (tipe)
        {
            case "start":
                SceneManager.LoadScene(lvlScore.GetComponent<LvlSelect>().lvl);
                break;
            case "quit":
                Application.Quit();
                break;
            case "exit":
                SceneManager.LoadScene(0);
                break;
            case "restart":
                SceneManager.LoadScene(restart);
                break;
            case "lvl":
                lvlScore.GetComponent<LvlSelect>().LvlRef();
                break;
        }
        
    }

    public void Lvl()
    {
        
    }
}
