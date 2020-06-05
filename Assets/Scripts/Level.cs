using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public GameObject marco;
    public Vector2 coordinates;
    public int state; // 0 Not explored; 1 failed exploration; 2 explored succesfully
    public bool reacheable;
    public bool mision;
    private Animator ani;
    public bool shop;
    public GameObject Shopicon;

    private void Start()
    {
        ani = GetComponent<Animator>();
        if (shop && PlayerStats.i.Objts[8]==1)
        {
            Shopicon.SetActive(true);
        }
    }

    private void Update()
    {
        //if (mision) marco.SetActive(false);
        ani.SetBool("reacheable",reacheable);
        ani.SetInteger("state",state); ;
    }
}
