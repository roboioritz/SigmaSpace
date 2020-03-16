using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{

    public Vector3 RotacionAleatoria;
   

    // Start is called before the first frame update
    void Start()
{
        RotacionAleatoria = new Vector3(Random.Range(-15, 15), Random.Range(-45, 45), Random.Range(-90, 90));
}

// Update is called once per frame
void Update()
{
        transform.Rotate(RotacionAleatoria*Time.deltaTime);
}

}
