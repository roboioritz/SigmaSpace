using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radius : MonoBehaviour
{
    public bool Onradius;    

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Onradius = true;            
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
