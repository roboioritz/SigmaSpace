﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject playerstats;    

    void Start()
    {
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
