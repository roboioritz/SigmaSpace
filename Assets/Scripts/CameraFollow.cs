using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float smooth;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position=(Vector3.Lerp(new Vector3(PlayerStats.i.destiny.x, 6, PlayerStats.i.destiny.y),new Vector3(player.transform.position.x,6, player.transform.position.z),1f));
    }
}
