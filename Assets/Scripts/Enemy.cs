using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Radius radius1;
    public Radius radius2;

    public GameObject Explosion;

    public string type;
    public int hp;
    public int value;
    
    void Start()
    {
        
    }
   
    void Update()
    {
        if(type == "Mine")
        {
            if (radius1.Onradius)
            {
                StartCoroutine(Explode());
                
            }            
        }
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

    /*private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Laser"&&Vector3.Magnitude(other.collider.transform.position - transform.position) <= 1)
        {
            hp -= PlayerStats.i.laserLvl + 1;
            if (hp <= 0) Dead();
            
        }
    }*/



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
