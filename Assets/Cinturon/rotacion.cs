using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacion : MonoBehaviour
{

    public List<GameObject> Asteroides;
    public List<Vector3> RotacionAleatoria;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Vector3 v in RotacionAleatoria)
        {
            //v.x = Random.Range(-15, 15);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject a in Asteroides)
        {
            a.transform.Rotate( new Vector3(12,-12,35)*Time.deltaTime,Space.World);
        }
    }
}
