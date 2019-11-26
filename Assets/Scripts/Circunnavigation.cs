using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circunnavigation : MonoBehaviour
{
    public float size;
    
    void Update()
    {
        if (transform.position.x > 15 + size || transform.position.x < -15 - size) transform.position = new Vector3(transform.position.x * -1 , 0, transform.position.z);
        if (transform.position.z > 15 + size || transform.position.z < -15 - size) transform.position = new Vector3(transform.position.x, 0,transform.position.z * -1);
        if (transform.position.x > 15.2f + size || transform.position.x < -15.2f - size) transform.position = new Vector3((15f*(transform.position.x/Mathf.Abs(transform.position.x))) , 0, transform.position.z);
        if (transform.position.z > 15.2f + size || transform.position.z < -15.2f  - size) transform.position = new Vector3(transform.position.x, 0, (15f * (transform.position.z / Mathf.Abs(transform.position.z))));
    }
}
