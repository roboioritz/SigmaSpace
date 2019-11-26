using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject proyectil;
    public GameObject fogonazo;

    private int moving = 1;


    void Start()
    {
        Destroy(gameObject, 4f);
        
    }

    private void Update()
    {
        transform.Translate(0, 15 * Time.deltaTime * moving, 0);
    }

    public void Impact()
    {

        Destroy(proyectil);
        moving = 0;
        Destroy(gameObject,0.25f);
        Instantiate(fogonazo,transform.position,transform.rotation);
        

    }

}
