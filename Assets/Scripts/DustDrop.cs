using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustDrop : MonoBehaviour
{
    private Vector2 Vel;
    private float alpha;
    void Start()
    {
        transform.position += new Vector3(0, 1, 0);
        Destroy(gameObject, 3.1f);
        Vel = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
        alpha = 1;
        transform.rotation = Quaternion.Euler(90,Random.Range(-180,180),0);
    }
    
    void Update()
    {
        transform.position += new Vector3(Vel.x*Time.deltaTime,0, Vel.y * Time.deltaTime);
        if (alpha > 0) alpha -= 0.33f * Time.deltaTime;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
    }
}
