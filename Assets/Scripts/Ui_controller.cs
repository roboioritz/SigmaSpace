using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Ui_controller : MonoBehaviour
{
    static public Ui_controller i;

    //public List<Quest> Quests;

    public GameObject mainMenu;
    public GameObject pause;
    public GameObject shop;
    public GameObject ingame;
    public GameObject load;
    public GameObject options;
    public GameObject SceneExit;
    public GameObject SectorExit;

    public GameObject lives;
    public GameObject liveprefab;

    public Animator shop_ani;
    public Animator load_ani;
    public Animator options_ani;
    
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
        if (shop != null) shop_ani = shop.GetComponent<Animator>();
        if (load != null) load_ani = load.GetComponent<Animator>();
        if (options != null) options_ani = options.GetComponent<Animator>();
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
        
        if(SceneManager.GetActiveScene().name!= "MainMenu" && SceneManager.GetActiveScene().name != "LevelScene")
        {
            //46.8f
        }

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
            case "shop":
                shop.SetActive(true);
                shop_ani.SetTrigger("Enable");
                break;
            case "load":
                load.SetActive(true);
                load_ani.SetTrigger("Enable");
                break;
            case "options":
                options.SetActive(true);
                options_ani.SetTrigger("Enable");
                break;
            case "sceneexit":
                SceneExit.SetActive(true);
                break;
            case "sectorexit":
                SectorExit.SetActive(true);
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
            case "shop":
                StartCoroutine(WaitShop());
                shop_ani.SetTrigger("Disable");
                break;
            case "load":
                StartCoroutine(WaitLoad());
                load_ani.SetTrigger("Disable");
                break;
            case "options":
                StartCoroutine(WaitOptions());
                options_ani.SetTrigger("Disable");
                break;
            case "sceneexit":
                SceneExit.SetActive(false);
                break;
            case "sectorexit":
                SectorExit.SetActive(false);
                break;
        }
    }

    IEnumerator WaitShop()
    {
        yield return new WaitForSeconds(0.6666f);
        shop.SetActive(false);
        ScenePlayerController.i.ShopClose();
    }

    IEnumerator WaitLoad()
    {
        yield return new WaitForSeconds(0.6666f);
        load.SetActive(false);
    }

    IEnumerator WaitOptions()
    {
        yield return new WaitForSeconds(0.6666f);
        options.SetActive(false);
    }

    public void SectorExitYes()
    {
        LevelManager.i.Exit();
    }

   /* public void SectorExitNo()
    {
        LevelManager.i.ExitClose();
    }*/

}
