using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radius : MonoBehaviour
{
    public bool Onradius;
    public Transform OtherPos;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Onradius = true;
            OtherPos = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Onradius = false;

        }
    }
}
