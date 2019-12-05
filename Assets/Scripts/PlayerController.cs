using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{  
    public float acceleration;
    public float rotSpeedmax;
    public float cooldown;
    public int armor;
    public int player;
    public GameObject ship;
    public GameObject Laser;
    public GameObject FirePoint;
    public GameObject trailPoint;
    public GameObject trail;
    public GameObject explosion;
    public Animator ani;   

    private GameObject objeto;
    private Rigidbody rb;
    private float rotSpeed;
    private bool isfuel = false;
    private bool inmune = false;
    private Vector3 inertia;
    private float fuel;
    private float countdown = 0;
    private string axis1;
    private string axis2;
    private string axis3;
    private string axis4;


    void Start()
    {
        StartCoroutine(Inmunity());
        armor = PlayerStats.i.armorLvl;
        cooldown = PlayerStats.i.cooldown;
        Laser = PlayerStats.i.lasers[PlayerStats.i.laserLvl];
        rb = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
        axis1 = "Fuel" + player;
        axis2 = "Horizontal" + player;
        axis3 = "Fire" + player;
        axis4 = "Special" + player;
    }

    
    void Update()
    {
        //position = transform.position;
        Fuel();
        Rotatate();
        Fire();        
        if(countdown>0)countdown --;

        //if (Tetranium.tetranium != null) Magnet();
        /*Debug.Log("("+ Mathf.Cos(ship.transform.eulerAngles.y) + "),("+ Mathf.Sin(ship.transform.eulerAngles.y) +")" 
                + "deg2rad(" + Mathf.Cos(Mathf.Deg2Rad*ship.transform.eulerAngles.y) + "),(" + Mathf.Sin(Mathf.Deg2Rad * ship.transform.eulerAngles.y) + ")"
                + "rad2deg(" + Mathf.Cos(Mathf.Rad2Deg * ship.transform.eulerAngles.y) + "),(" + Mathf.Sin(Mathf.Rad2Deg * ship.transform.eulerAngles.y) + ")");*/

        //if (isfuel) trail.GetComponent<ParticleSystem>().startSpeed = -16 + Mathf.Pow(Mathf.Abs(Mathf.Sqrt(Mathf.Pow(inertia.x,2) + Mathf.Pow(inertia.z, 2))),4);        
        /*if (transform.position.y != 0) transform.Translate(0, -transform.position.y * Time.deltaTime, 0);));
        /*if (transform.position.y != 0) transform.Translate(0, -transform.position.y * Time.deltaTime, 0);
        if (transform.rotation.x != 0) transform.Rotate(-transform.rotation.x * Time.deltaTime, 0, 0);
        if (transform.rotation.z != 0) transform.Rotate(0, 0, -transform.rotation.z * Time.deltaTime);*/
    }

    private void Fuel()
    {
        fuel = -Input.GetAxis(axis1) * acceleration * Time.deltaTime;
        inertia += new Vector3(-Input.GetAxis(axis1) * acceleration * Time.deltaTime * Mathf.Sin(Mathf.Deg2Rad * ship.transform.eulerAngles.y), 0,
                               -Input.GetAxis(axis1) * acceleration * Time.deltaTime * Mathf.Cos(Mathf.Deg2Rad * ship.transform.eulerAngles.y));
        transform.Translate(inertia);
        if (Input.GetAxis(axis1) != 0 && !isfuel)
        {
            ani.SetTrigger("isfuel");
            isfuel = true;
            //objeto = Instantiate(trail,trailPoint.transform.position,ship.transform.rotation);
            //objeto.transform.SetParent(ship.transform);
            
        }
        if (Input.GetAxis(axis1) == 0 && isfuel)
        {
            ani.SetTrigger("notfuel");
            isfuel = false;            
        }
    }

    private void Rotatate()
    {

        //rb.MoveRotation(rb.rotation * Quaternion.Euler(0, Input.GetAxis("Horizontal") * rotSpeedmax * Time.deltaTime, 0));
        //print(Input.GetAxis("Horizontal"));
        ship.transform.Rotate(0, Input.GetAxis(axis2) * rotSpeedmax * Time.deltaTime, 0);

    }

    private void Fire()
    {
        if (Input.GetButton(axis3) && countdown == 0 )
        {
            countdown = cooldown;
            Instantiate(Laser, FirePoint.transform.position, FirePoint.transform.rotation);
        }
    }

    public void Dead()
    {
        PlayerStats.i.levels[(PlayerStats.i.destiny.x + 2) + 5 * (-PlayerStats.i.destiny.y+2)] = 1;
        LevelManager.i.SendMessage("End");
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Asteroid" || collision.collider.tag == "Player")
        {
            Vector2 direction = new Vector2(transform.position.x - collision.transform.position.x, transform.position.z - collision.transform.position.z);            
            float module2 = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y);
            inertia = new Vector3(direction.x * .05f / module2,0, direction.y * .05f / module2);
            if (!inmune)
            {
                inmune = true;
                armor--;
                StartCoroutine(Inmunity());
                if (armor < 0)
                {
                    Instantiate(explosion,transform.position,transform.rotation);
                    Dead();
                }

            }

            //play sound
        }

    }

    IEnumerator Inmunity()
    {
        yield return new WaitForSeconds(1f);
        inmune = false;
        LevelManager.i.SendMessage("GetStart");
    }
    
    

}
