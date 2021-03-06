﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveFile : MonoBehaviour
{
    public int FileNum;
    public int isnew; //0 new 1 create
    public string FileName;
    public bool existe;
    public bool writing;

    public GameObject NameOfFile;
    public Text FileText;
    public GameObject NewGame;
    public Text NewGameText;
    public GameObject Player;
    public GameObject InputField;
    public Text positionText;
    public Text moneyText;

    public static PlayerStats i;
    public Vector2Int position;
    public Vector2Int destiny;
    public int cooldown;

    public List<GameObject> lasers;

    public int engineLvl;
    public int laserLvl;
    public int armorLvl;
    public int magnetLvl;

    public int money;

    public struct Levels
    {
        public int[] X;
    }
    public Levels[] Y;

    public int[] Objts;
    public bool[] Asteroidex;

    public int[] levels;
    public bool[] quests;

    /*void Start()
    {
        print("123");
        LoadStats();
        if (!existe) { print("lololo"); NameOfFile.SetActive(false); NewGame.SetActive(true); NewGameText.text = "NewGame"; }
        else { NameOfFile.SetActive(true); NewGame.SetActive(false);FileText.text = "" + FileName; }
    }*/

    private void OnEnable()
    {                        
        Y = new Levels[25];
        Objts = new int[21];
        Asteroidex = new bool[15];
        for (int i = 0; i < 25; i++)
        {
            Y[i].X = new int[25];
        }
        LoadStats();
        if (!existe) { NameOfFile.SetActive(false); NewGame.SetActive(true); NewGameText.text = "NewGame"; InputField.SetActive(false); }
        else if (existe) { NameOfFile.SetActive(true); NewGame.SetActive(false); FileText.text = "" + FileName; InputField.SetActive(false); }
    }

    void Update()
    {
        FileText.text = "" + FileName;
        positionText.text = "[" + position.x + "][" + position.y + "]";
        moneyText.text = "" + money;
        if(writing && (Input.GetKeyDown(KeyCode.Return) || Input.GetButton("Start1")))
        {
            NewFile();
        } 
    }

    public void SaveStats()
    {
        SaveSystem.SaveStats(this,FileNum);
    }

    public void LoadStats()
    {
        FileData data = SaveSystem.LoadFile(FileNum);
        if (data != null)
        {
            FileName = data.FileName;            
            position.x = data.position[0]; position.y = data.position[1];
            destiny.x = data.destiny[0]; destiny.y = data.destiny[1];

            cooldown = data.cooldown;
            engineLvl = data.engineLvl;
            laserLvl = data.laserLvl;
            armorLvl = data.armorLvl;
            magnetLvl = data.magnetLvl;
            money = data.money;
            levels = new int[25];
            Objts = new int[21];
            Asteroidex = new bool[15];
            for (int y = 0; y < 25; y++)
            {
                for (int x = 0; x < 25; x++)
                {
                    Y[y].X[x] = data.levels[y,x];                                    
                }

                if (y < 21) Objts[y] = data.Objts[y];
                if (y < 15) Asteroidex[y] = data.Asteroidex[y];
            }            
            
            isnew = data.isnew;
            if (isnew == 0) existe = false;
            else if (isnew == 1) existe = true;                      
        }
        else if (data == null)
        {
            existe = false;
            print(isnew);
        }        
    }

    public void ButtoPush()
    {
        if (existe)
        {
            Instantiate(Player);
            MenuManager.i.Play();
            PlayerStats.i.Load(this);
            SceneManager.LoadScene("LevelScene");
        }
        else if (!existe)
        {
            NewGame.SetActive(false);
            InputField.SetActive(true);
            writing = true;
        }
    }


    public void NewFile()
    {
        writing = false;
        FileName =  InputField.GetComponent<InputField>().text;
        isnew = 1;
        position.x = 0; position.y = 0;
        destiny.x = 0; destiny.y = 0;

        cooldown = 30;
        engineLvl = 0;
        laserLvl = 0;
        armorLvl = 0;
        magnetLvl = 0;
        money = 2000;
        levels = new int[25];

        for (int y = 0; y < 25; y++)
        {
            for (int x = 0; x < 25; x++)
            {
                Y[y].X[x] = 0;                
            }

            if (y < 21) Objts[y] = 1; // poner a 0
            if (y < 15) Asteroidex[y] = true; //poner a false

        }

        //for (int i = 0; i < 25; i++) { levels[i] = 0; }
        SaveSystem.SaveStats(this, FileNum);        
        { NameOfFile.SetActive(false); NewGame.SetActive(true); NewGameText.text = "NewGame"; InputField.SetActive(false); }
        existe = true;
        //LoadStats();
        OnEnable();
        //SceneManager.LoadScene("LevelScene");
    }

    public void DeleteFile()
    {
        FileName = "";
        isnew = 0;
        position.x = 0; position.y = 0;
        destiny.x = 0; destiny.y = 0;

        cooldown = 30;
        engineLvl = 0;
        laserLvl = 0;
        armorLvl = 0;
        magnetLvl = 0;
        money = 0;
        levels = new int[25];
        //for (int i = 0; i < 25; i++) { levels[i] = 0; }
        SaveSystem.SaveStats(this, FileNum);
        { NameOfFile.SetActive(false); NewGame.SetActive(true); NewGameText.text = "NewGame"; InputField.SetActive(false); }
    }

    public Levels[] Array()
    {
        Levels[] w;
        w = new Levels[25];
        for (int i = 0; i < 25; i++)
        {
            w[i].X = new int[25];
        }
        return w;
    }

}
