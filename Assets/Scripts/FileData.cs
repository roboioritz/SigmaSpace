using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FileData 
{
    public string FileName;
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

    public int[] levels;
    public bool[] quests;

    public FileData(SaveFile PlayerStats)
    {
        FileName = PlayerStats.FileName;
        position = new int[2]; position[0] = PlayerStats.position.x; position[1] = PlayerStats.position.y;
        destiny = new int[2]; destiny[0] = PlayerStats.destiny.x; destiny[1] = PlayerStats.destiny.y;

        cooldown = PlayerStats.cooldown;
        engineLvl = PlayerStats.engineLvl;
        laserLvl = PlayerStats.laserLvl;
        armorLvl = PlayerStats.armorLvl;
        magnetLvl = PlayerStats.magnetLvl;
        levels = new int[25];
        for(int i = 0; i < 25; i++) { levels[i] = PlayerStats.levels[i]; }
    }
}
