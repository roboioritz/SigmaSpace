using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePlayerController : MonoBehaviour
{
    static public ScenePlayerController i;
    public bool moving;
    public Vector2Int departure;
    public int engine;
    public Vector2Int moveCount;
    public GameObject Negro;
    public GameObject camera;
    private Animator Negro_ani;

    private bool paused;
    private bool shopopen;
    private bool entering = false;

    void Start()
    {
        Negro_ani = Negro.GetComponent<Animator>();
        i = this;
        Time.timeScale = 1f;
        transform.position = new Vector3(PlayerStats.i.position.x, 0.1f, PlayerStats.i.position.y);
        departure = PlayerStats.i.position;
        
    }    

    void Update()
    {
        engine = PlayerStats.i.engineLvl;
        if (!paused)
        {
            Move();

            /*if (Input.GetButtonDown("Start1"))
            {
                paused = true;
                Ui_controller.i.pause.SetActive(true);
                Time.timeScale = 0f;
            }*/
            if (!shopopen)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    shopopen = true;
                    Ui_controller.i.Enable("shop");
                    //Time.timeScale = 0f;
                }
            }
            /*else if (Input.GetButtonDown("Fuel1"))
            {
               /* shopopen = false;
                Ui_controller.i.shop.SetActive(false);
                Time.timeScale = 1f;
            }*/
        }
        /*else if (Input.GetButtonDown("Start1"))
        {
            paused = false;
            Ui_controller.i.pause.SetActive(false);
            Time.timeScale = 1f;
        }*/

        if (Input.GetKeyDown(KeyCode.Escape)&&paused==false)
        {
            StartCoroutine(PauseWait());
            Ui_controller.i.Enable("sceneexit");
            //Time.timeScale = 0f;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && paused == true)
        {
            StartCoroutine(PauseWait());
            Ui_controller.i.Disable("sceneexit");
            //Time.timeScale = 1f;
        }


    }

    public void Move()
    {
        //&& Mathf.Abs(moveCount.x) + Mathf.Abs(moveCount.y) + 1 * Mathf.Sign(Input.GetAxis("Horizontal")) * Mathf.Sign(moveCount.x) < engine + 1 
        //&& Mathf.Abs(departure.x) + Mathf.Abs(moveCount.x) + 1 * Mathf.Sign(Input.GetAxis("Horizontal")) * Mathf.Sign(moveCount.x) < 3)
        //departure.y + moveCount.y + 1 * Mathf.Sign(-Input.GetAxis("Vertical1"))
        if (!moving && Input.GetAxis("Vertical1") != 0 && + Mathf.Abs(moveCount.y + 1 * Mathf.Sign(-Input.GetAxis("Vertical1"))) + Mathf.Abs(moveCount.x) < engine+1
                                                        && departure.y + moveCount.y + 1 * Mathf.Sign(-Input.GetAxis("Vertical1")) < 13
                                                        && departure.y + moveCount.y + 1 * Mathf.Sign(-Input.GetAxis("Vertical1")) > -13)//el limite del mapa +1
        {
            moving = true;
            StartCoroutine(Moving());
            moveCount.y += Mathf.RoundToInt(1 * Mathf.Sign(-Input.GetAxis("Vertical1")));
            transform.rotation = Quaternion.Euler(0,-90 * Mathf.Sign(-Input.GetAxis("Vertical1")),0);
        }
        if (!moving && Input.GetAxis("Horizontal1") != 0 && +Mathf.Abs(moveCount.y ) + Mathf.Abs(moveCount.x + 1 * Mathf.Sign(Input.GetAxis("Horizontal1"))) < engine + 1
                                                      && departure.x + moveCount.x + 1 * Mathf.Sign(Input.GetAxis("Horizontal1")) < 13
                                                        && departure.x + moveCount.x + 1 * Mathf.Sign(Input.GetAxis("Horizontal1")) > -13)
        {
            moving = true;
            StartCoroutine(Moving());
            moveCount.x += Mathf.RoundToInt(1 * Mathf.Sign(Input.GetAxis("Horizontal1")));
            transform.rotation = Quaternion.Euler(0, 90 + 90 * Mathf.Sign(-Input.GetAxis("Horizontal1")), 0);
        }       

        if (moving) transform.Translate(2*Time.deltaTime,0,0);

        if (!moving && Input.GetAxis("Fire1") != 0 && !entering)
        {
            entering = true;
            StartCoroutine(EnterSector());
            //SceneManager.LoadScene("["+ (departure.x + moveCount.x).ToString() +"][" + (departure.y + moveCount.y).ToString() + "]");
            //SceneManager.LoadScene("Pruebas sector");
            //PlayerStats.i.destiny = new Vector2Int(departure.x + moveCount.x, departure.y + moveCount.y);
        }
    }

    IEnumerator Moving()
    {
        yield return new WaitForSeconds(0.5f);
        moving = false;
        transform.position = new Vector3Int(departure.x + moveCount.x, 0, departure.y + moveCount.y);
    }

    public void Exit()
    {
        PlayerStats.i.Save();
        PlayerStats.i.Resetear();
        SceneManager.LoadScene("MainMenu");
    }

    public void Contine()
    {
        paused = false;
        Ui_controller.i.pause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ShopClose()
    {
        shopopen = false;
        Time.timeScale = 1f;
        PlayerStats.i.Save();
    }

    public void ExitClose()
    {
        paused = false;
        //Time.timeScale = 1f;
        Ui_controller.i.Disable("sceneexit");
    }

    IEnumerator PauseWait()
    {
        yield return new WaitForSeconds(0.2f);
        if (paused) paused = false;
        else paused = true;
    }

    IEnumerator EnterSector()
    {
        Negro_ani.SetTrigger("ZumIn");
        camera.SendMessage("ZumIn");
        yield return new WaitForSeconds(1f);
        if (Application.CanStreamedLevelBeLoaded("[" + (departure.x + moveCount.x).ToString() + "][" + (departure.y + moveCount.y).ToString() + "]"))
        {
            SceneManager.LoadScene("[" + (departure.x + moveCount.x).ToString() + "][" + (departure.y + moveCount.y).ToString() + "]");
        }
        else SceneManager.LoadScene("ProceduralLevel");
        //SceneManager.LoadScene("Pruebas sector");
        //SceneManager.LoadScene("[0][0]");
        PlayerStats.i.destiny = new Vector2Int(departure.x + moveCount.x, departure.y + moveCount.y);
        
    }

}
