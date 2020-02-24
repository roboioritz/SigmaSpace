using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject proyectil;
    public GameObject fogonazo;

    private int moving = 1;
    public float speed;

    void Start()
    {
        if(tag=="Slow") Destroy(gameObject, 3f);
        else Destroy(gameObject, 4f);        
    }

    private void Update()
    {
        transform.Translate(0, speed * Time.deltaTime * moving, 0);
    }

    public void Impact()
    {
        Destroy(proyectil);
        moving = 0;
        Destroy(gameObject);
        Instantiate(fogonazo,transform.position,transform.rotation);
    }

}
