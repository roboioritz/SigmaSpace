using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetranium : MonoBehaviour
{
    private Vector3 basevel;
    private Vector3 inertia;
    private Vector3 dir;
    public int magnetlvl; // temporal
    private Vector3 rotVel;

    void Awake()
    {
        basevel = new Vector3(Random.Range(-.5f, .5f), 0,Random.Range(-.5f, .5f)) * Time.deltaTime;
        rotVel = new Vector3(Random.Range(-60.0f, 60.0f), Random.Range(-60.0f, 60.0f), Random.Range(-60.0f, 60.0f));
    }

    void Update()
    {
        dir =  PlayerController.i.transform.position - transform.position;
        float module = Mathf.Sqrt(dir.magnitude);
        dir.Normalize();     
        //transform.Translate(inertia.x * Time.deltaTime,0,inertia.z*Time.deltaTime,Space.World);
        inertia += new Vector3(dir.x, 0, dir.z) * PlayerStats.i.magnetLvl * Time.deltaTime * 0.1f /(module*module);
        transform.Translate(basevel+inertia, Space.World);

        transform.Rotate(rotVel * Time.deltaTime, Space.Self);
        //Magnet(LevelManager.posP1, LevelManager.posP1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Play sound recoger tetrenium
            //other.SendMessage("PickUp"); //PlayerControler.PickUp("Tetranium",Value=1)
            PlayerStats.i.money++;
            Destroy(gameObject);
        }

        if (other.tag == "Asteroid" || other.tag == "Tetranium")
        {
            Vector2 direction = new Vector2(transform.position.x - other.transform.position.x, transform.position.z - other.transform.position.z);
            Vector2 otherdir = other.GetComponent<Asteroid>().Vel;
            //float module1 = Mathf.Sqrt(dir.x * dir.x + dir.y * dir.y);
            float module1 = Mathf.Sqrt(otherdir.x * otherdir.x + otherdir.y * otherdir.y);
            float module2 = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y);
            dir = new Vector2(direction.x * (module1+1) / module2, direction.y * (module1 + 1) / module2);
        }
    }

    /*public void Magnet(Vector3 pos1, Vector3 pos2)
    {        
        Vector2 dir2 = new Vector2 (pos1.x - transform.position.x, pos1.y - transform.position.z);
        Vector2 dir3 = new Vector2(pos2.x - transform.position.x, pos2.y - transform.position.z);
        float dist1 = Mathf.Abs(Mathf.Sqrt(dir2.x* dir2.x + dir2.y * dir2.y));
        float dist2 = Mathf.Abs(Mathf.Sqrt(dir3.x * dir3.x + dir3.y * dir3.y));
        if (!LevelManager.twoPlayers)
        {
            if (dist1 > 1 || dist1 < -1) dir += new Vector2(magnetlvl * Time.deltaTime * dir2.x / Mathf.Pow(dist1, 2), magnetlvl * Time.deltaTime * dir2.y / Mathf.Pow(dist1, 2));
        }
        else
        {
            if (dist1 > dist2) { if (dist1 > 1 || dist1 < -1) dir += new Vector2(magnetlvl * Time.deltaTime * dir2.x / Mathf.Pow(dist1, 2), magnetlvl * Time.deltaTime * dir2.y / Mathf.Pow(dist1, 2)); }
            if (dist1 < dist2) { if (dist2 > 1 || dist2 < -1) dir += new Vector2(magnetlvl * Time.deltaTime * dir3.x / Mathf.Pow(dist2, 2), magnetlvl * Time.deltaTime * dir3.y / Mathf.Pow(dist2, 2)); }
        }
    }*/
}
