using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> Items;   

    void Start()
    {
        SetItemValues();
    }

    
    void Update()
    {
        SetItemValues();
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

    }

    public void CargadorDeEscudo()
    {

    }

    public void Turbolaser()
    {

    }

}
