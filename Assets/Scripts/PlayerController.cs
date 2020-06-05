using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public static PlayerController i;

    public float acceleration;
    public float rotSpeedmax;
    public float cooldown;
    public int armor;
    public int player;
    public GameObject self;
    public GameObject ship;
    public GameObject Laser;
    public GameObject FirePoint;
    public GameObject trailPoint;
    public GameObject trail;
    public GameObject explosion;
    public Animator ani;
    public float limit;
    public Vector3 inertia;

    public AudioSource ASource;
    public AudioSource ASource2;
    public List<AudioClip> Clip;

    private GameObject objeto;
    private Rigidbody rb;
    private float rotSpeed;
    private bool isfuel = false;
    private bool inmune = false;
    private bool laserOk = true;
    private bool shieldOk = true;
    private float fuel;
    private float countdown = 0;
    private string axis1;
    private string axis2;
    private string axis3;
    private string axis4;
    private float damaging;
    private float slow;
    private float slowed;
    private Vector2 overEngine;
    

    void Start()
    {
        i = this;
        StartCoroutine(Inmunity());
        armor = PlayerStats.i.armorLvl;
        cooldown = PlayerStats.i.cooldown;
        if (PlayerStats.i.Objts[6] == 1) cooldown /= 1.5f;
        Laser = PlayerStats.i.lasers[PlayerStats.i.laserLvl];
        rb = GetComponent<Rigidbody>();
        ani = GetComponent<Animator>();
        axis1 = "Fuel" + player;
        axis2 = "Horizontal" + player;
        axis3 = "Fire" + player;
        axis4 = "Special" + player;
        inertia = Vector3.zero;
        laserOk = false;
        shieldOk = false;
        StartCoroutine(LoadHability());
    }
    
    void Update()
    {        
        //position = transform.position;
        Fuel();
        Rotatate();
        Fire();
        Hability();
        if (countdown>0)countdown --;

        if (Mathf.Sign(inertia.x) != Mathf.Sign(Mathf.Sin(Mathf.Deg2Rad * ship.transform.eulerAngles.y)))
        {
            overEngine.x = 2f + Mathf.Abs(inertia.x);
        }
        else overEngine.x = 1;
        if (Mathf.Sign(inertia.z) != Mathf.Sign(Mathf.Cos(Mathf.Deg2Rad * ship.transform.eulerAngles.y)))
        {
            overEngine.y = 2f + Mathf.Abs(inertia.z);
        }
        else overEngine.y = 1;

        if (slowed > 0)
        {
            slowed -= Time.deltaTime;
            slow = 0.5f;
        }
        else slow = 1;

        limit = Mathf.Sqrt(Mathf.Pow(inertia.x, 2) + Mathf.Pow(inertia.z, 2));

        //if (Tetranium.tetranium != null) Magnet();
        /*Debug.Log("("+ Mathf.Cos(ship.transform.eulerAngles.y) + "),("+ Mathf.Sin(ship.transform.eulerAngles.y) +")" 
                + "deg2rad(" + Mathf.Cos(Mathf.Deg2Rad*ship.transform.eulerAngles.y) + "),(" + Mathf.Sin(Mathf.Deg2Rad * ship.transform.eulerAngles.y) + ")"
                + "rad2deg(" + Mathf.Cos(Mathf.Rad2Deg * ship.transform.eulerAngles.y) + "),(" + Mathf.Sin(Mathf.Rad2Deg * ship.transform.eulerAngles.y) + ")");*/

        //if (isfuel) trail.GetComponent<ParticleSystem>().startSpeed = -16 + Mathf.Pow(Mathf.Abs(Mathf.Sqrt(Mathf.Pow(inertia.x,2) + Mathf.Pow(inertia.z, 2))),4);        
        /*if (transform.position.y != 0) transform.Translate(0, -transform.position.y * Time.deltaTime, 0);));
        /*if (transform.position.y != 0) transform.Translate(0, -transform.position.y * Time.deltaTime, 0);
        if (transform.rotation.x != 0) transform.Rotate(-transform.rotation.x * Time.deltaTime, 0, 0);
        if (transform.rotation.z != 0) transform.Rotate(0, 0, -transform.rotation.z * Time.deltaTime);*/

        if (!inmune && damaging>1)
        {
            inmune = true;
            armor--;
            StartCoroutine(Inmunity());
            if (armor < 0)
            {
                Instantiate(explosion, transform.position, transform.rotation);
                Dead();
            }
            damaging = 0;
        }


    }

    private void Fuel()
    {
        fuel = -Input.GetAxis(axis1) * acceleration * Time.deltaTime;
        inertia += new Vector3(-Input.GetAxis(axis1) * acceleration * Time.deltaTime * Mathf.Sin(Mathf.Deg2Rad * ship.transform.eulerAngles.y) * overEngine.x * slow, 0,
                               -Input.GetAxis(axis1) * acceleration * Time.deltaTime * Mathf.Cos(Mathf.Deg2Rad * ship.transform.eulerAngles.y) * overEngine.y * slow);
        /*if (Mathf.Sqrt(Mathf.Pow(inertia.x, 2) + Mathf.Pow(inertia.z, 2)) > 0.28f)
        {
            inertia -= 2 * new Vector3(-Input.GetAxis(axis1) * acceleration * Time.deltaTime * Mathf.Sin(Mathf.Deg2Rad * ship.transform.eulerAngles.y) * slow, 0,
                               -Input.GetAxis(axis1) * acceleration * Time.deltaTime * Mathf.Cos(Mathf.Deg2Rad * ship.transform.eulerAngles.y) * slow);
        }  */

        if (Mathf.Abs(inertia.x) >= 0.165f) inertia.x = 0.165f * Mathf.Sign(inertia.x);
        if(Mathf.Abs(inertia.z) >= 0.165f) inertia.z = 0.165f * Mathf.Sign(inertia.z);

        transform.Translate(inertia);

        if (Input.GetAxis(axis1) != 0 && !isfuel)
        {
            ani.SetTrigger("isfuel");
            isfuel = true;
            ASource.clip = Clip[0];
            ASource.Play();
            //objeto = Instantiate(trail,trailPoint.transform.position,ship.transform.rotation);
            //objeto.transform.SetParent(ship.transform);            
        }

        if (Input.GetAxis(axis1) == 0 && isfuel)
        {
            ani.SetTrigger("notfuel");
            isfuel = false;
            ASource.Stop();
        }
    }

    private void Rotatate()
    {
        //rb.MoveRotation(rb.rotation * Quaternion.Euler(0, Input.GetAxis("Horizontal") * rotSpeedmax * Time.deltaTime, 0));
        //print(Input.GetAxis("Horizontal"));
        ship.transform.Rotate(0, Input.GetAxis(axis2) * rotSpeedmax * Time.deltaTime, 0);
        if (Input.GetAxis(axis2) != 0 && Input.GetAxis(axis1) !=0)
        {
            inertia *= 0.99f;
        }
    }

    private void Fire()
    {
        if (Input.GetButton(axis3) && countdown <= 0 )
        {
            countdown = cooldown;
            Instantiate(Laser, FirePoint.transform.position, FirePoint.transform.rotation);            
            ASource2.Play();
        }
    }

    private void Hability()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (PlayerStats.i.Objts[5] == 2&& laserOk)
            {
                StartCoroutine(UltraLaser());
            }
            else if(PlayerStats.i.Objts[4] == 2 && shieldOk)
            {
                StartCoroutine(Escudo());
            }
        }
    }

    IEnumerator UltraLaser()
    {
        cooldown /= 2;
        laserOk = false;
        yield return new WaitForSeconds(3f);
        cooldown *= 2;
        LivesAndCooldown.i.start();
        yield return new WaitForSeconds(30f);
        laserOk = true;
    }

    IEnumerator Escudo()
    {
        inmune = true;
        shieldOk = false;
        yield return new WaitForSeconds(5f);
        inmune = false;
        LivesAndCooldown.i.start();
        yield return new WaitForSeconds(30f);
        shieldOk = true;
    }

    IEnumerator LoadHability()
    {
        yield return new WaitForSeconds(30f);
        shieldOk = true;
        laserOk = true;
    }


    public void Dead()
    {
        //PlayerStats.i.levels[(PlayerStats.i.destiny.x + 2) + 5 * (-PlayerStats.i.destiny.y+2)] = 1;
        LevelManager.i.SendMessage("Loose");       
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
        }

        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LaserEnemy")
        {
            if (!inmune)
            {
                inmune = true;
                armor--;
                StartCoroutine(Inmunity());
                if (armor < 0)
                {
                    Instantiate(explosion, transform.position, transform.rotation);
                    Dead();
                }
            }
            other.SendMessage("Impact");
        }

        if (other.tag == "Slow")
        {
            inertia = inertia / 2;
            slowed = 3;
            

        }

        if (other.tag == "Enemy")
        {
            print("ER");
            other.SendMessage("Dead");
        }

    }

    private void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.tag == "Thunder")
        {
            damaging+=Time.deltaTime;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Thunder")
        {
            damaging = 0;
        }
    }

    IEnumerator Inmunity()
    {
        yield return new WaitForSeconds(1f);
        inmune = false;
        LevelManager.i.SendMessage("GetStart");
    }      

    public void TakeDamage(Transform Damager)
    {
        //rb.AddExplosionForce(100, Damager.position, 50);
        Vector3 dir =  transform.position - Damager.position;
        float module = Mathf.Sqrt(dir.magnitude);
        //dir.Normalize();
        inertia += dir / (module * module);
        print("aa");
        if (!inmune )
        {
            inmune = true;
            armor--;
            StartCoroutine(Inmunity());
            if (armor < 0)
            {
                Instantiate(explosion, transform.position, transform.rotation);
                Dead();
            }            
            
            
        }
    }
}
