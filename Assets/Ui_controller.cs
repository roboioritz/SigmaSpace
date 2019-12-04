using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_controller : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject pause;
    public GameObject shop;
    public GameObject ingame;

    

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void Enable(string menu)
    {
        switch (menu)
        {
            case "mainmenu":
                mainMenu.SetActive(true);
                break;
            case "pausa":
                pause.SetActive(true);
                break;
            case "ingame":
                ingame.SetActive(true);
                break;
            case "cristals":
                shop.SetActive(true);
                break;            
        }
    }

    public void Disable(string menu)
    {
        switch (menu)
        {
            case "mainmenu":
                mainMenu.SetActive(false);
                break;
            case "pausa":
                pause.SetActive(false);
                break;
            case "ingame":
                ingame.SetActive(false);
                break;
            case "cristals":
                shop.SetActive(false);
                break;
        }
    }
}
