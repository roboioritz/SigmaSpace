using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    static public MenuManager i;
    public GameObject playerstats;
    public bool loading = false;

    void Start()
    {   i=this;
        Screen.SetResolution(1280 , 607, false); //1024/485 funciona proporcion 0.4736  1920/910  1280/607  1680/796
        //PlayerStats.i.Resetear();        
        print("resoluciones" + Screen.width + "/" + Screen.height);
        //Ui_controller.i.Enable("mainmenu");
       
    }
    
    void Update()
    {        
        /*if (Input.GetKeyDown(KeyCode.Return)|| Input.GetButton("Start1"))
        {
            Instantiate(playerstats, transform.position, transform.rotation);
            SceneManager.LoadScene("LevelScene");
        }*/

        if(loading && Input.anyKeyDown) SceneManager.LoadScene("LevelScene");
    }

    public void Play()
    {
        //Instantiate(playerstats, transform.position, transform.rotation);
        StartCoroutine(LoadScreen());
    }

    public void Exit()
    {
        Application.Quit();
    }

    IEnumerator LoadScreen()
    {
        Ui_controller.i.Enable("loadscreen");
        yield return new WaitForSeconds(1f);
        loading = true;
        Ui_controller.i.Enable("any");
    }
}
