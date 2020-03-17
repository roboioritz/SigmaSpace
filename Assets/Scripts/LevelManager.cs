using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    static public LevelManager i;
    static public Vector3 posP1;
    static public Vector3 posP2;
    public GameObject Player1;
    public GameObject Player2;
    public Ui_controller UI;
    public bool start = false;
    public int asteroidCount;

    private bool paused;

    public static bool twoPlayers = false;
    
    void Start()
    {               
        Time.timeScale = 1f;
        //Ui_controller.i.Enable("ingame");
        UI.Enable("ingame");
        i = this;
        Instantiate(Player1, transform.position, Quaternion.identity);
    }
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Exit();
        if (!paused)
        {
            posP1 = Player1.transform.position;
            if (twoPlayers) posP2 = Player2.transform.position;

            if (!twoPlayers && (Input.GetKeyDown(KeyCode.Return) || Input.GetButton("Start2")))
            {
                twoPlayers = true;
                //Instantiate(Player2, transform.position, Quaternion.identity);
            }
            if (asteroidCount <= 0)
            {
                print("hola");
                //playsound victori
                //PlayerStats.i.levels[(PlayerStats.i.destiny.x + 2) + 5 * (-PlayerStats.i.destiny.y + 2)] = 2;
                //PlayerStats.i.position = PlayerStats.i.destiny;
                PlayerStats.i.LevelPass();
                StartCoroutine(Back());
                
            }

            /*if (Input.GetButtonDown("Start1"))
            {
                paused = true;
                Ui_controller.i.pause.SetActive(true);
                Time.timeScale = 0f;
            }*/
        }
        /*else if (Input.GetButtonDown("Start1"))
        {
            paused = false;
            Ui_controller.i.pause.SetActive(false);
            Time.timeScale = 1f;
        }*/

        /*if (Input.GetKeyDown(KeyCode.Escape) && paused == false)
        {
            //StartCoroutine(PauseWait());
            paused = true;
            Ui_controller.i.Enable("sectorexit");
            Time.timeScale = 0f;
        }        */

    }

    public void GetStart()
    {
        start = true;
    }

    public void End()
    {
        StartCoroutine(Back());
    }

    public void Add()
    {
        asteroidCount++;
    }

    public void Remove()
    {
        asteroidCount--;
    }

    IEnumerator Back()
    {
        yield return new WaitForSeconds(5f);
        PlayerStats.i.Save();
        SceneManager.LoadScene("LevelScene");
    }

    public void Exit()
    {
        SceneManager.LoadScene("LevelScene");
    }    

    /*public void ExitClose()
    {
        paused = false;
        Time.timeScale = 1f;
        Ui_controller.i.Disable("sectorexit");
    }*/

}
