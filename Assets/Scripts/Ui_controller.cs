﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Ui_controller : MonoBehaviour
{
    static public Ui_controller i;

    public List<Quest> Quests;

    public GameObject mainMenu;
    public GameObject pause;
    public GameObject shop;
    public GameObject ingame;

    public Text shopengine;
    public Text shoparmor;
    public Text shoplaser;
    public Text shopmagnet;

    public TextMeshProUGUI money;
    /*public TextMeshProUGUI questTitle;
    public TextMeshProUGUI questDescription;
    public TextMeshProUGUI questCompletion;*/

    

    

    void Start()
    {
        i = this;
    }
    
    void Update()
    {
        money.text = "" + PlayerStats.i.money;
        /*questTitle.text = "" + Quests[0].title;
        questDescription.text = "" + Quests[0].description;
        questCompletion.text = "" + Quests[0].completionDescription;*/

            if (PlayerStats.i.engineLvl <= 2)
                shopengine.text = "Engine Lv." + PlayerStats.i.engineLvl + " : " + (PlayerStats.i.engineLvl * 10 + 10);
            else
                shopengine.text = "MAX";

            if (PlayerStats.i.armorLvl <= 5)
                shoparmor.text = "Armor Lv." + PlayerStats.i.armorLvl + " : " + (PlayerStats.i.armorLvl * 10 + 10);
            else
                shoparmor.text = "MAX";

            if (PlayerStats.i.laserLvl <= 4)
                shoplaser.text = "Laser Lv." + PlayerStats.i.laserLvl + " : " + (PlayerStats.i.laserLvl * 10 + 10);
            else
                shoplaser.text = "MAX";

            if (PlayerStats.i.magnetLvl <= 3)
                shopmagnet.text = "Magnet Lv." + PlayerStats.i.magnetLvl + " : " + (PlayerStats.i.magnetLvl * 10 + 10);
            else
                shopmagnet.text = "MAX";
        
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