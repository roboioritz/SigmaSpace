using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> Items;

    public Text engineLvl;
    public Text laserLvl;
    public Text armorLvl;
    public Text magnetLvl;

    public GameObject AsteroidexGameobject;

    void Start()
    {
        SetItemValues();
    }

    
    void Update()
    {
        SetItemValues();
        engineLvl.text = "" + PlayerStats.i.engineLvl;
        laserLvl.text = "" + PlayerStats.i.laserLvl;
        armorLvl.text = "" + PlayerStats.i.armorLvl;
        magnetLvl.text = "" + PlayerStats.i.magnetLvl;
    }

    void SetItemValues()
    {
        foreach (Item item in Items)
        {
            item.state = PlayerStats.i.Objts[item.num];
        }
    }

    public void Asteroidex()
    {
        AsteroidexGameobject.SetActive(true);
    }

    public void CargadorDeEscudo()
    {
        if (Items[4].state == 1)
        {
            Items[4].state = 2;
            PlayerStats.i.Objts[4] = 2;
            if (Items[5].state == 2)
            {
                Items[5].state = 1;
                PlayerStats.i.Objts[5] = 1;
            }
        }
    }

    public void Turbolaser()
    {
        if (Items[5].state == 1)
        {
            Items[5].state = 2;
            PlayerStats.i.Objts[5] = 2;
            if (Items[4].state == 2)
            {
                Items[4].state = 1;
                PlayerStats.i.Objts[4] = 1;
            }
        }
    }

}
