using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public bool isActive;

    public string title;
    public string description;
    public string completionDescription;
    public string reward;
    public GameObject playerStats;

    public List<Level> levels;
    public List<Quest> next;

    private int amount;

    public void Update()
    {
        if (isActive)
        {
            amount = 0;
            foreach (Level l in levels)
            {
                if (l.state==2) amount++;
            }
            if (amount == levels.Count) Completed();
        }
    }

    private void Completed()
    {
        playerStats.SendMessage(""+reward);
        foreach (Quest q in next) q.isActive = true;
        isActive = false;
        
    }
}
