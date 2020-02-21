using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Radius radius1;
    public Radius radius2;

    public GameObject Explosion;
    public float acceleration =10000000f;

    public string type;
    public int hp;
    public int value;

    public Vector3 inertia;
    
    void Start()
    {
        
    }
   
    void Update()
    {
        if(type == "Mine" || type == "ExpDrone")
        {
            if (radius1.Onradius)
            {
                StartCoroutine(Explode());                
            }            
        }

        if(type != "Mine" && radius2.Onradius)
        {            
            transform.LookAt(radius2.OtherPos);
            inertia = new Vector3(acceleration *  Mathf.Sin(Mathf.Deg2Rad * (transform.eulerAngles.y)), 0,
                                  acceleration *  Mathf.Cos(Mathf.Deg2Rad * (transform.eulerAngles.y)));
            
        }
        transform.Translate(inertia);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Laser" && Vector3.Magnitude(other.transform.position - transform.position) <= 1)
        {
            other.SendMessage("Impact");
            hp -= PlayerStats.i.laserLvl + 1;
            if (hp <= 0) Dead();
        }   
        
    }    

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(0.5f);
        if (radius1.Onradius) PlayerController.i.TakeDamage(transform);
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);        
    }

    public void Dead()
    {
        if (radius1.Onradius&&(type=="Mine"||type=="ExpDrone")) PlayerController.i.TakeDamage(transform);
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
