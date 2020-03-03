using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveFile : MonoBehaviour
{
    public int FileNum;
    public string FileName;
    public bool existe;

    public GameObject NameOfFile;
    public Text FileText;
    public GameObject NewGame;
    public Text NewGameText;

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

    public int[] levels;
    public bool[] quests;

    void Start()
    {
        LoadStats();
        if (!existe) { NameOfFile.SetActive(false); NewGame.SetActive(true); NewGameText.text = "NewGame"; }
        else { NameOfFile.SetActive(true); NewGame.SetActive(false);FileText.text = "" + FileName; }

    }
    
    void Update()
    {
        
    }

    public void SaveStats()
    {
        SaveSystem.SaveStats(this,FileNum);
    }

    public void LoadStats()
    {
        FileData data = SaveSystem.LoadFile(FileNum);

        FileName = data.FileName;
        position.x = data.position[0]; position.y = data.position[1];
        destiny.x = data.destiny[0]; destiny.y = data.destiny[1];

        cooldown = data.cooldown;
        engineLvl = data.engineLvl;
        laserLvl = data.laserLvl;
        armorLvl = data.armorLvl;
        magnetLvl = data.magnetLvl;
        levels = new int[25];
        for (int i = 0; i < 25; i++) { levels[i] = data.levels[i]; }

        if (data == null)
        {
             existe = false;
        }
        else existe = true;
    }



}
