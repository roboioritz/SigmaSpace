using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float smooth;
    public Animator ani;

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    
    void Update()
    {
        transform.position=(Vector3.Lerp(new Vector3(PlayerStats.i.destiny.x, 12, PlayerStats.i.destiny.y),new Vector3(player.transform.position.x,12, player.transform.position.z),1.5f));
    }

    public void ZumIn()
    {
        ani.SetTrigger("ZumIn");
    }

}
