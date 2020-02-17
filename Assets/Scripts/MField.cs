using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MField : MonoBehaviour
{
    public Transform parent;
    public float radio;
    public GameObject rallos;
    public GameObject r;
    public bool charged;


    private void Start()
    {
        //GetComponent<SphereCollider>().radius = radio;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Asteroid>().type == "Charged"&& !charged)
        {
            charged = true;
            Vector3 vector = ((parent.position - other.transform.position) / 2) + other.transform.position;
            //float dist = Mathf.Sqrt((vector.x * vector.x) + (vector.y * vector.y));
            //Instantiate(rallos, vector, Quaternion.Euler(0, Mathf.Rad2Deg*(Mathf.Asin(vector.y/dist)), 0));
            r = Instantiate(rallos, vector, Quaternion.identity);
            r.GetComponent<Thunder>().T1 = parent.gameObject;
            r.GetComponent<Thunder>().T2 = other.gameObject;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Asteroid>().type == "Charged" && !charged)
        {
            charged = true;
            Vector3 vector = ((parent.position - other.transform.position) / 2) + other.transform.position;
            //float dist = Mathf.Sqrt((vector.x * vector.x) + (vector.y * vector.y));
            //Instantiate(rallos, vector, Quaternion.Euler(0, Mathf.Rad2Deg*(Mathf.Asin(vector.y/dist)), 0));
            r = Instantiate(rallos, vector, Quaternion.identity);
            r.GetComponent<Thunder>().T1 = parent.gameObject;
            r.GetComponent<Thunder>().T2 = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(r);
        charged = false;
    }
}
