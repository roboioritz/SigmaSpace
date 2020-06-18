using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Vector2 coordinates;
    public int state; // 0 Not explored; 1 failed exploration; 2 explored succesfully
    public bool reacheable;
    private Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        ani.SetBool("reacheable",reacheable);
        ani.SetInteger("state",state); ;
    }
}
