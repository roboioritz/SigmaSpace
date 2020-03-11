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
                }break;
            case "armor":
                if (PlayerStats.i.money >= (PlayerStats.i.armorLvl * 10 + 10) && PlayerStats.i.armorLvl <= 5)
                {
                    PlayerStats.i.money -= (PlayerStats.i.armorLvl * 10 + 10);
                    PlayerStats.i.armorLvl++;
                }break;
            case "laser":
                if (PlayerStats.i.money >= (PlayerStats.i.laserLvl * 10 + 10) && PlayerStats.i.laserLvl <= 4)
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
                LevelArray.Y[y].X[x].state = PlayerStats.i.LevelArray.Y[y].X[x];
            }
        }
    }

    void CalculateEngineRange()
    {

        for (int y = 0; y < PlayerStats.i.engineLvl + 1; y++)
        {
            for (int x = 0; x < PlayerStats.i.engineLvl + 1 - y; x++) 
            {
                //if (PlayerStats.i.position.y + 12 + y < 25 && PlayerStats.i.position.x + 12 + x < 25) LevelArray.Y[-PlayerStats.i.position.y + 12 + y].X[PlayerStats.i.position.x + 12 + x].reacheable = true;
                if (-PlayerStats.i.position.y + 12 + y <  25 && PlayerStats.i.position.x + 12 + x <  25) LevelArray.Y[-PlayerStats.i.position.y + 12 + y].X[PlayerStats.i.position.x + 12 + x].reacheable = true;
                if (-PlayerStats.i.position.y + 12 + y > -25 && PlayerStats.i.position.x + 12 + x <  25) LevelArray.Y[-PlayerStats.i.position.y + 12 - y].X[PlayerStats.i.position.x + 12 + x].reacheable = true;
                if (-PlayerStats.i.position.y + 12 + y <  25 && PlayerStats.i.position.x + 12 + x > -25) LevelArray.Y[-PlayerStats.i.position.y + 12 + y].X[PlayerStats.i.position.x + 12 - x].reacheable = true;
                if (-PlayerStats.i.position.y + 12 + y > -25 && PlayerStats.i.position.x + 12 + x > -25) LevelArray.Y[-PlayerStats.i.position.y + 12 - y].X[PlayerStats.i.position.x + 12 - x].reacheable = true;
            }
        }


        /*for (int i = 0; i < PlayerStats.i.engineLvl+1; i++)
      {
          for (int j = 0; j < PlayerStats.i.engineLvl-i+1; j++)
          {

              stages[PlayerStats.i.position.x + 2 + i, -PlayerStats.i.position.y + 2 + j].reacheable = true;
              stages[PlayerStats.i.position.x + 2 - i, -PlayerStats.i.position.y + 2 + j].reacheable = true;
              stages[PlayerStats.i.position.x + 2 + i, -PlayerStats.i.position.y + 2 - j].reacheable = true;
              stages[PlayerStats.i.position.x + 2 - i, -PlayerStats.i.position.y + 2 - j].reacheable = true;
          }
      }*/

        /*for (int i = 0; i < PlayerStats.i.engineLvl + 1; i++)
        {
            if (-PlayerStats.i.position.y + 2 + i <= 4 && -PlayerStats.i.position.y + 2 + i >= 0)
                stages[-PlayerStats.i.position.y + 2 + i, PlayerStats.i.position.x + 2].reacheable = true;
            if (-PlayerStats.i.position.y + 2 - i <= 4 && -PlayerStats.i.position.y + 2 - i >= 0 )
                stages[-PlayerStats.i.position.y + 2 - i, PlayerStats.i.position.x + 2].reacheable = true;
            if (PlayerStats.i.position.x + 2 + i <= 4 && PlayerStats.i.position.x + 2 + i >= 0)
                stages[-PlayerStats.i.position.y + 2, PlayerStats.i.position.x + 2 + i].reacheable = true;
            if (PlayerStats.i.position.x + 2 - i <= 4 && PlayerStats.i.position.x + 2 - i >= 0 )
                stages[-PlayerStats.i.position.y + 2, PlayerStats.i.position.x + 2 - i].reacheable = true;

            if (i >= 2)
            {
                if (-PlayerStats.i.position.y + 1 + i <= 4 && -PlayerStats.i.position.y + 1 + i >= 0 && PlayerStats.i.position.x + 3 <= 4 && PlayerStats.i.position.x + 3 >= 0)
                    stages[-PlayerStats.i.position.y + 1 + i, PlayerStats.i.position.x + 3].reacheable = true;
                if (-PlayerStats.i.position.y + 3 - i <= 4 && -PlayerStats.i.position.y + 3 - i >= 0 && PlayerStats.i.position.x + 1 <= 4 && PlayerStats.i.position.x + 1 >= 0)
                    stages[-PlayerStats.i.position.y + 3 - i, PlayerStats.i.position.x + 1].reacheable = true;
                if (-PlayerStats.i.position.y + 1 <= 4 && -PlayerStats.i.position.y + 1 >= 0 && PlayerStats.i.position.x + 1 + i <= 4 && PlayerStats.i.position.x + 1 + i >= 0)
                    stages[-PlayerStats.i.position.y + 1, PlayerStats.i.position.x + 1 + i].reacheable = true;
                if (-PlayerStats.i.position.y + 3 <= 4 && -PlayerStats.i.position.y + 3 >= 0 && PlayerStats.i.position.x + 3 - i <= 4 && PlayerStats.i.position.x + 3 - i >= 0)
                    stages[-PlayerStats.i.position.y + 3, PlayerStats.i.position.x + 3 - i].reacheable = true;*/
    }
}



