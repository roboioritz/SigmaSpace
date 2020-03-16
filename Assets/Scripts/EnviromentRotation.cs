using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentRotation : MonoBehaviour
{
    public float speed,X,Z;

    void Start()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,Random.Range(-180,180), transform.rotation.eulerAngles.z);
    }
    
    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
