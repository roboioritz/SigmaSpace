using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Vector2 Vel;
    public Vector3 rotVel;
    public string type;
    public float hp;
    public int value;
    public int Lvl;
    
    public GameObject dropPrefab1;
    public GameObject dropPrefab2;
    public GameObject esplosion;

    private float size;
    private bool start;

    /*private void Awake()
    {
        if (Vel == Vector2.zero)
        {
            Vel = new Vector2(Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f));
        }
        //hp = 5;
    }*/

    /*private void Awake()
    {
        
    }*/

    private void Start()
    {
        if (type != "Metalic")        LevelManager.i.Add();

        /*if (Vel == Vector2.zero)
        {
            Vel = new Vector2(Random.Range(-1.0f * Lvl, 1.0f * Lvl), Random.Range(-1.0f * Lvl, 1.0f * Lvl));
        }

        if (rotVel == Vector3.zero)
        {
            rotVel = new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f));
        }

        size = hp;
        transform.rotation = new Quaternion (Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360),0);*/
    }


    void Update()
    {
        if (!start)
        {
            if (Vel == Vector2.zero)
            {
                Vel = new Vector2(Random.Range(-1.0f * Lvl, 1.0f * Lvl), Random.Range(-1.0f * Lvl, 1.0f * Lvl));
            }

            if (rotVel == Vector3.zero)
            {
                rotVel = new Vector3(Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f), Random.Range(-20.0f, 20.0f));
            }

            //size = hp;
            transform.rotation = new Quaternion(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360), 0);
            start = true;
        }


        transform.Translate(Vel.x * Time.deltaTime, 0, Vel.y * Time.deltaTime,Space.World);
        transform.Rotate(rotVel * Time.deltaTime,Space.Self);
        
        if (size > hp) size -= (size - hp + 3) * Time.deltaTime;

        if (type == "Normal")
        {
            transform.localScale = new Vector3(1f + 0.02f * size, 1f + 0.02f * size, 1f + 0.02f * size);
            //GetComponent<Circunnavigation>().size = 1f + 0.09f * size;
        }

        if (type == "Comet")
        {
            Magnet(LevelManager.posP1, LevelManager.posP1);
        }

        //transform.position = new Vector3(transform.position.x,0, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Laser" )
        {
            GameObject objeto = Instantiate(esplosion,other.transform.position,Quaternion.identity); Destroy(objeto, 1f);
            other.SendMessage("Impact");

            if(type != "Metalic") hp -= PlayerStats.i.laserLvl+1; //playerStats.Laserlvl en el futuro
            if (hp <= 0) Dead();
        }

        /*if (other.tag == "Player")
        {
            other.SendMessage("Dead");
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Asteroid" )
        {
            Vector2 direction = new Vector2(transform.position.x - collision.transform.position.x, transform.position.z - collision.transform.position.z);
            float module1 = Mathf.Sqrt(Vel.x * Vel.x + Vel.y * Vel.y);
            float module2 = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y);
            Vel = new Vector2(direction.x * module1 / module2, direction.y * module1 / module2);
        }
    }

    private void Dead()
    {
        //Instantiate particle asteroid dead
        if (dropPrefab1 != null)
        {
            Instantiate(dropPrefab1, transform.position, Quaternion.identity);
            Instantiate(dropPrefab1, transform.position, Quaternion.identity);
        }
        if (dropPrefab2 != null)for (int i = 0; i < value; i++) Instantiate(dropPrefab2, transform.position, Quaternion.identity);
        LevelManager.i.SendMessage("Remove");
        Instantiate(esplosion,transform.position,transform.rotation);
        Destroy(gameObject);
    }

    public void Magnet(Vector3 pos1, Vector3 pos2)
    {

        Vector2 dir2 = new Vector2(pos1.x - transform.position.x, pos1.y - transform.position.z);
        Vector2 dir3 = new Vector2(pos2.x - transform.position.x, pos2.y - transform.position.z);
        float dist1 = Mathf.Abs(Mathf.Sqrt(dir2.x * dir2.x + dir2.y * dir2.y));
        float dist2 = Mathf.Abs(Mathf.Sqrt(dir3.x * dir3.x + dir3.y * dir3.y));
        if (!LevelManager.twoPlayers)
        {
            if (dist1 > 1 || dist1 < -1) Vel += new Vector2(Lvl * Time.deltaTime * dir2.x / Mathf.Pow(dist1, 2), Lvl * Time.deltaTime * dir2.y / Mathf.Pow(dist1, 2));
        }
        else
        {
            if (dist1 > dist2) { if (dist1 > 1 || dist1 < -1) Vel += new Vector2(Lvl * Time.deltaTime * dir2.x / Mathf.Pow(dist1, 2), Lvl * Time.deltaTime * dir2.y / Mathf.Pow(dist1, 2)); }
            if (dist1 < dist2) { if (dist2 > 1 || dist2 < -1) Vel += new Vector2(Lvl * Time.deltaTime * dir3.x / Mathf.Pow(dist2, 2), Lvl * Time.deltaTime * dir3.y / Mathf.Pow(dist2, 2)); }
        }
    }
}
