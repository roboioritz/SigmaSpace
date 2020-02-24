using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Radius radius1;
    public Radius radius2;

    public GameObject Explosion;
    public GameObject Proyectile;
    public GameObject Deploy;
    public float acceleration;

    public string type;
    public int hp;
    public int value;
    public float cooldown;
    private float cool;

    public Vector3 inertia;
    
    void Start()
    {

        cool = cooldown;
        if (type == "Hive")
        {
            transform.rotation = Quaternion.Euler(0, Random.Range(-180, 180), 0);
            inertia = new Vector3(acceleration * Time.deltaTime * Mathf.Sin(Mathf.Deg2Rad * (transform.eulerAngles.y)), 0,
                                  acceleration * Time.deltaTime * Mathf.Cos(Mathf.Deg2Rad * (transform.eulerAngles.y)));
        }
        if (type == "Missil")
        {
            Destroy(gameObject, 10f);
            transform.LookAt(radius2.OtherPos);
            inertia = new Vector3(acceleration * Time.deltaTime * Mathf.Sin(Mathf.Deg2Rad * (transform.eulerAngles.y)), 0,
                                  acceleration * Time.deltaTime * Mathf.Cos(Mathf.Deg2Rad * (transform.eulerAngles.y)));
        }
    }
   
    void Update()
    {
        if (type == "Misiler")
        {
            Deploy.transform.LookAt(radius2.OtherPos);
        }

        if(type == "Mine" || type == "ExpDrone" || type=="Missil")
        {
            if (radius1.Onradius)
            {
                StartCoroutine(Explode());                
            }            
        }

        if(type == "ExpDrone" && radius2.Onradius)
        {            
            transform.LookAt(radius2.OtherPos);
            inertia = new Vector3(acceleration *  Mathf.Sin(Mathf.Deg2Rad * (transform.eulerAngles.y)), 0,
                                  acceleration *  Mathf.Cos(Mathf.Deg2Rad * (transform.eulerAngles.y)));
            
        }

        if ((type == "Drone" || type == "Slower" || type == "Misiler") && radius2.Onradius)
        {
            transform.LookAt(radius2.OtherPos);
            if (radius1.Onradius == false)
            {                
                inertia = new Vector3(acceleration  * Mathf.Sin(Mathf.Deg2Rad * (transform.eulerAngles.y)), 0,
                                      acceleration * Mathf.Cos(Mathf.Deg2Rad * (transform.eulerAngles.y)));
            }

            if (radius1.Onradius == true)
            {
                inertia = new Vector3(acceleration * 0.25f * Mathf.Sin(Mathf.Deg2Rad * (transform.eulerAngles.y)), 0,
                                      acceleration * 0.25f * Mathf.Cos(Mathf.Deg2Rad * (transform.eulerAngles.y)));
            }

        }
        if (type == "Drone" || type == "Slower"||type == "Misiler") 
        {
            cool -= Time.deltaTime;
            if (cool <= 0 && radius1.Onradius)
            {
                cool = cooldown;
                if(type == "Misiler") Instantiate(Proyectile, Deploy.transform.position, Deploy.transform.rotation);
                else Instantiate(Proyectile,transform.position, Quaternion.Euler(90, transform.rotation.eulerAngles.y, 0));
            }
        }
        if ( type == "Hive")
        {
            cool -= Time.deltaTime;
            if (cool <= 0)
            {                
                cool = cooldown;
                Instantiate(Proyectile,Deploy.transform.position, Quaternion.Euler(0, transform.rotation.eulerAngles.y,0));
            }
        }

        transform.Translate(inertia,Space.World);
        
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
        if (radius1.Onradius && (type == "Mine" || type == "ExpDrone" || type == "Missil")) PlayerController.i.TakeDamage(transform);
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
