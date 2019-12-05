using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public bool isActive;
    public int missionN;
    public string title;
    public string description;
    public string completionDescription;
    public string reward;
    //public GameObject playerStats;

    public int[] levels;
    public List<Quest> next;

    private int amount;

    private void Start()
    {
        //isActive = PlayerStats.i.quests[missionN];
    }

    public void Update()
    {
        isActive = PlayerStats.i.quests[missionN];
        if (isActive)
        {
            amount = 0;
            for(int i = 0; i < levels.Length; i++)
            {
                if (PlayerStats.i.levels[i] == 2) amount++;
            }
            if (amount == levels.Length) Completed();
        }
    }

    private void Completed()
    {
        PlayerStats.i.SendMessage(""+reward);        
        isActive = false;
        PlayerStats.i.quests[missionN + 1] = true;
    }
}
