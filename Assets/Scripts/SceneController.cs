using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneController : MonoBehaviour
{    
    public List<Level> Levels;
    //public List<Quest> Quests;
    public GameObject player;
    public Ui_controller UI;
    //public int[,] stages = new int[5,5];
    public Level[,] stages = new Level[5, 5];
    public LevelArray LevelArray;
    private void Start()
    {        
        UI.Enable("ingame");
        LoadLevelStates();
        CalculateEngineRange();

        /*int count = 0;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                stages[i, j] = Levels[count];
                //stages[i, j].state = PlayerStats.i.levels[count];
                count++;
            }
        }*/


        /*for (int i = 0; i < Quests.Count; i++)
        {
            Quests[i].isActive = PlayerStats.i.quests[i];
        } */
    }

    private void Update()
    {
        //print(LevelArray.Y[0].X[24].coordinates.x);
    }

    public void Buy(string product)
    {
        switch (product)
        {
            case "engine":
                if (PlayerStats.i.money >= (PlayerStats.i.engineLvl * 10 + 10) && PlayerStats.i.engineLvl <= 2)
                {
                    PlayerStats.i.money -= (PlayerStats.i.engineLvl * 10 + 10);
                    PlayerStats.i.engineLvl++;
                    CalculateEngineRange();
                }
                break;
            case "armor":
                if (PlayerStats.i.money >= (PlayerStats.i.armorLvl * 10 + 10) && PlayerStats.i.armorLvl <= 5)
                {
                    PlayerStats.i.money -= (PlayerStats.i.armorLvl * 10 + 10);
                    PlayerStats.i.armorLvl++;
                }break;
            case "laser":
                if (PlayerStats.i.money >= (PlayerStats.i.laserLvl * 10 + 10) && PlayerStats.i.laserLvl <= 2)
                {
                    PlayerStats.i.money -= (PlayerStats.i.laserLvl * 10 + 10);
                    PlayerStats.i.laserLvl++;
                }break;
            case "magnet":
                if (PlayerStats.i.money >= (PlayerStats.i.magnetLvl * 10 + 10) && PlayerStats.i.magnetLvl <= 3)
                {
                    PlayerStats.i.money -= (PlayerStats.i.magnetLvl * 10 + 10);
                    PlayerStats.i.magnetLvl++;
                }break;
        }
    }


    void LoadLevelStates()
    {
        for (int y = 0; y < 25; y++)
        {
            for (int x = 0; x < 25; x++)
            {
                //LevelArray.Y[y].X[x].state = PlayerStats.i.Y[y].X[x];
                //LevelArray.Y[y].X[x].state = PlayerStats.i.LevelArray.Y[y].X[x];
                LevelArray.Y[y].X[x].state = PlayerStats.i.levels[y, x];
            }
        }
    }

    void CalculateEngineRange()
    {
        ResetReach();
        for (int y = 0; y < PlayerStats.i.engineLvl + 1; y++)
        {
            for (int x = 0; x < PlayerStats.i.engineLvl + 1 - y; x++) 
            {
               if (-PlayerStats.i.position.y + 12 + y <  25 && PlayerStats.i.position.x + 12 + x <  25) LevelArray.Y[-PlayerStats.i.position.y + 12 + y].X[PlayerStats.i.position.x + 12 + x].reacheable = true;               
               if (-PlayerStats.i.position.y + 12 - y > -1 && PlayerStats.i.position.x + 12 + x <  25) LevelArray.Y[-PlayerStats.i.position.y + 12 - y].X[PlayerStats.i.position.x + 12 + x].reacheable = true;
               if (-PlayerStats.i.position.y + 12 + y <  25 && PlayerStats.i.position.x + 12 - x > - 1) LevelArray.Y[-PlayerStats.i.position.y + 12 + y].X[PlayerStats.i.position.x + 12 - x].reacheable = true;
               if (-PlayerStats.i.position.y + 12 - y > -1 && PlayerStats.i.position.x + 12 - x > - 1) LevelArray.Y[-PlayerStats.i.position.y + 12 - y].X[PlayerStats.i.position.x + 12 - x].reacheable = true;
            }
        }        
    }

    void ResetReach()
    {
        for (int i = 0; i < 25; i++)
        {
            for (int j = 0; j < 25; j++)
            {
                LevelArray.Y[i].X[j].reacheable = false;
            }
        }
    }
}



