using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FileData 
{
    public string FileName;
    public int isnew;
    //public static PlayerStats i;
    public int[] position;
    public int[] destiny;
    public int cooldown;

    //public List<GameObject> lasers;

    public int engineLvl;
    public int laserLvl;
    public int armorLvl;
    public int magnetLvl;

    public int money;

    public int[] Objts;
    public bool[] Asteroidex;

    public int[,] levels;
    public int[] Quests;

    public FileData(SaveFile PlayerStats)
    {
        isnew = PlayerStats.isnew;
        FileName = PlayerStats.FileName;
        position = new int[2]; position[0] = PlayerStats.position.x; position[1] = PlayerStats.position.y;
        destiny = new int[2]; destiny[0] = PlayerStats.destiny.x; destiny[1] = PlayerStats.destiny.y;

        cooldown = PlayerStats.cooldown;
        engineLvl = PlayerStats.engineLvl;
        laserLvl = PlayerStats.laserLvl;
        armorLvl = PlayerStats.armorLvl;
        magnetLvl = PlayerStats.magnetLvl;

        money = PlayerStats.money;
        Quests = new int[20];
        levels = new int[25,25];
        Objts = new int[21];
        Asteroidex = new bool[15];
        for(int y = 0; y < 25; y++)
        {
            for (int x = 0; x < 25; x++)
            {
                //money = PlayerStats.money;
                //levels[y, x] = PlayerStats.LevelArray.Y[y].X[x];
                levels[y, x] = PlayerStats.levels[y, x];
            }

            if (y < 20) Quests[y] = PlayerStats.Quests[y];
            if (y < 21) Objts[y] = PlayerStats.Objts[y];
            if (y < 15) Asteroidex[y] = PlayerStats.Asteroidex[y];
        }
    }
}
