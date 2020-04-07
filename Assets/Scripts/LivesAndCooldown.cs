using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesAndCooldown : MonoBehaviour
{
    static public LivesAndCooldown i;

    public GameObject armorlv1;
    public GameObject armorlv2;
    public GameObject armorlv3;
    public GameObject armorlv4;
    public GameObject armorlv5;
    public GameObject armorlv6;

    public GameObject Coldown;
    public Image cooldown;
    public GameObject F;

    private float cool = 0;

    void Start()
    {
        i = this;
        if (PlayerStats.i.Objts[4] == 2 || PlayerStats.i.Objts[5] == 2)
        {
            Coldown.SetActive(true);
        }
    }

    void Update()
    {
        if (PlayerController.i.armor < 6) armorlv6.SetActive(false);
        if (PlayerController.i.armor < 5) armorlv5.SetActive(false);
        if (PlayerController.i.armor < 4) armorlv4.SetActive(false);
        if (PlayerController.i.armor < 3) armorlv3.SetActive(false);
        if (PlayerController.i.armor < 2) armorlv2.SetActive(false);
        if (PlayerController.i.armor < 1) armorlv1.SetActive(false);

        cool += Time.deltaTime;
        cooldown.fillAmount = cool / 30;

        if (cool > 30) F.SetActive(true); else F.SetActive(false);
    }

    public void start()
    {
        cool = 0;
    }
}
