using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public string FileName;
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

    private void Awake()
    {
        i = this;
        DontDestroyOnLoad(i);
    }

    public void Resetear()
    {
        Destroy(gameObject);
    }

    
}
