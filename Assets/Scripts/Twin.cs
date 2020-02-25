using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twin : MonoBehaviour
{

    public Vector3 rotVel;
    public Vector3 Vel;

    void Start()
    {
        rotVel = new Vector3(0, Random.Range(80.0f, 40.0f) * Mathf.Sign(Random.Range(-1, 1)), 0);
        Vel = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f , 1.0f ));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotVel * Time.deltaTime, Space.Self);
        transform.Translate(Vel.x * Time.deltaTime, 0, Vel.y * Time.deltaTime, Space.World);
    }
}
