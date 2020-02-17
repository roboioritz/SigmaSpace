using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    public GameObject T1;
    public GameObject T2;

    private float dist;

    void Start()
    {
        //transform.rotation = Quaternion.Euler(90,0,0);
    }

    
    void Update()
    {
        transform.LookAt(T1.transform);

        transform.position = ((T1.transform.position - T2.transform.position) / 2) + T2.transform.position;
        dist = Mathf.Sqrt(Mathf.Pow(T1.transform.position.x- T2.transform.position.x,2)+ Mathf.Pow(T1.transform.position.y - T2.transform.position.y, 2)+ Mathf.Pow(T1.transform.position.z - T2.transform.position.z, 2));
        transform.localScale = new Vector3(1,1,dist*0.5f);
    }
}
