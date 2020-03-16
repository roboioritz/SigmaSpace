using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uwu : MonoBehaviour
{
    public float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, speed, 0) * Time.deltaTime);
        if (transform.rotation.eulerAngles.y > 265) transform.rotation = Quaternion.EulerAngles(0,220 * Mathf.Deg2Rad,0);
        //print(transform.rotation.eulerAngles.y);
    }
}
