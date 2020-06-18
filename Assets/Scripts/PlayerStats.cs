using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public string FileName;
    public int isnew;
    public int FileNum;
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

    public LevelArrayStats  LevelArray;

    public struct levels
    {
        public int[] X;
    }
    public levels[] Y;

    public int[] Objts;
    public bool[] Asteroidex;

    //public int[,] levels;
    public bool[] quests;

    private void Awake()
    {
        i = this;
        DontDestroyOnLoad(i);
    }

    public void Resetear()
    {
        Destroy(gameObject);
    }

    public void Load(SaveFile data)
    {
        FileName = data.FileName;
        isnew = data.isnew;
        FileNum = data.FileNum;
        position.x = data.position.x; position.y = data.position.y;
        destiny.x = data.destiny.x; destiny.y = data.destiny.y;

        cooldown = data.cooldown;
        engineLvl = data.engineLvl;
        laserLvl = data.laserLvl;
        armorLvl = data.armorLvl;
        magnetLvl = data.magnetLvl;
        money = data.money;

        for (int y = 0; y < 25; y++)
        {
            for (int x = 0; x < 25; x++)
            {
                LevelArray.Y[y].X[x] = data.Y[y].X[x];                
            }

            if (y < 21) Objts[y] = data.Objts[y];
            if (y < 15) Asteroidex[y] = data.Asteroidex[y];
        }

        if (laserLvl > 3) laserLvl = 3;
    }

    public void Save()
    {
        SaveFile data = new SaveFile();

        data.isnew = isnew;
        data.FileName = FileName;
        data.FileNum = FileNum;
        data.position.x = position.x; data.position.y = position.y;
        data.destiny.x = destiny.x; data.destiny.y = destiny.y;

        data.cooldown = cooldown;
        data.engineLvl = engineLvl;
        data.laserLvl = laserLvl;
        data.armorLvl = armorLvl;
        data.magnetLvl = magnetLvl;
        data.money =money;
        data.Y = data.Array();
        for(int i = 0; i < 25; i++)
        {
            //data.Y[y] = data.Array();
        }
            data.Objts = new int[21];
        data.Asteroidex = new bool[15];
        for (int y = 0; y < 25; y++)
        {
            
            data.Y[y].X = new int[25];
            for (int x = 0; x < 25; x++)
            {
                //data.Y[y].X[x] = Y[y].X[x];
            }

            if (y < 21) data.Objts[y] = Objts[y];
            if (y < 15) data.Asteroidex[y] = Asteroidex[y];

        }        
        data.SaveStats();
    }

    public void LevelPass()
    {
        position = destiny;
    }
   

}
