using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveFile : MonoBehaviour
{
    public int FileNum;
    public string FileName;
    public bool existe;
    public bool writing;

    public GameObject NameOfFile;
    public Text FileText;
    public GameObject NewGame;
    public Text NewGameText;
    public GameObject Player;
    public GameObject InputField;

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

    /*void Start()
    {
        print("123");
        LoadStats();
        if (!existe) { print("lololo"); NameOfFile.SetActive(false); NewGame.SetActive(true); NewGameText.text = "NewGame"; }
        else { NameOfFile.SetActive(true); NewGame.SetActive(false);FileText.text = "" + FileName; }
    }*/

    private void OnEnable()
    {
        
        LoadStats();
        if (!existe) {NameOfFile.SetActive(false); NewGame.SetActive(true); NewGameText.text = "NewGame"; InputField.SetActive(false); }
        else { NameOfFile.SetActive(true); NewGame.SetActive(false); FileText.text = "" + FileName; }
    }

    void Update()
    {
        FileText.text = "" + FileName;
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
            for (int i = 0; i < 25; i++) { levels[i] = data.levels[i]; }
        }
        else if (data == null)
        {
             existe = false;
        }        
    }

    public void ButtoPush()
    {
        if (existe)
        {
            Instantiate(Player);
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
        
        position.x = 0; position.y = 0;
        destiny.x = 0; destiny.y = 0;

        cooldown = 30;
        engineLvl = 0;
        laserLvl = 0;
        armorLvl = 0;
        magnetLvl = 0;
        money = 0;
        levels = new int[25];
        for (int i = 0; i < 25; i++) { levels[i] = 0; }
        SaveSystem.SaveStats(this, FileNum);        
        { NameOfFile.SetActive(false); NewGame.SetActive(true); NewGameText.text = "NewGame"; InputField.SetActive(false); }
        existe = true;
        //LoadStats();
        OnEnable();
        //SceneManager.LoadScene("LevelScene");
    }
}
