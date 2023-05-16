using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public SpawnE sp;
    public GameObject obj;
    public Vector3 vec;

    void Update()
    {
        transform.position = obj.transform.position + vec;
        //transform.position = obj.transform.position + new Vector3(-0.7899f, 0.1248f);
    }
}
