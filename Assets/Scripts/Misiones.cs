using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Misiones : MonoBehaviour
{
    public static Misiones i;

    public GameObject Mision1;
    public Text Mision1Name;
    public Text Mision1Description;

    public GameObject Mision2;
    public Text Mision2Name;
    public Text Mision2Description;

    public GameObject Mision3;
    public Text Mision3Name;
    public Text Mision3Description;

    public List<Quest> quests;
    public int activeamount;

    void Start()
    {
        i = this;
        MisionAmount();
    }      

    public void MisionAmount()
    {
        activeamount = 0;
        foreach (Quest q in quests)
        {
            if (q.state == 1)
            {
                activeamount++;
                if (activeamount == 1)
                {
                    Mision1.SetActive(true);
                    Mision1Description.text = q.description;
                    Mision1Name.text = q.Name;
                }
                if (activeamount == 2)
                {
                    Mision2.SetActive(true);
                    Mision2Description.text = q.description;
                    Mision2Name.text = q.Name;
                }
                if (activeamount == 3)
                {
                    Mision3.SetActive(true);
                    Mision3Description.text = q.description;
                    Mision3Name.text = q.Name;
                }
            }
        }

        if (activeamount == 0)
        {
            Mision1.SetActive(false);
            Mision2.SetActive(false);
            Mision3.SetActive(false);
        }
        if (activeamount == 1)
        {
            Mision2.SetActive(false);
            Mision3.SetActive(false);
        }
        if (activeamount == 2)
        {            
            Mision3.SetActive(false);
        }
    }
}
