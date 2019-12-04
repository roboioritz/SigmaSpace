﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject playerstats;

    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Instantiate(playerstats, transform.position, transform.rotation);
            SceneManager.LoadScene("LevelScene");
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("LevelScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
