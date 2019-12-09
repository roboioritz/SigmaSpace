using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject playerstats;    

    void Start()
    {        
        Screen.SetResolution(1920,910,false); //1024/485 funciona proporcion 0.4736  1920/910 
        //PlayerStats.i.Resetear();
        Ui_controller.i.Enable("mainmenu");
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)|| Input.GetButton("Start1"))
        {
            Instantiate(playerstats, transform.position, transform.rotation);
            SceneManager.LoadScene("LevelScene");
        }
    }

    public void Play()
    {
        Instantiate(playerstats, transform.position, transform.rotation);
        SceneManager.LoadScene("LevelScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
