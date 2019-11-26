using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public List<Level> Levels;
    public List<Quest> Quests;
    public PlayerStats playerStats;
    public ScenePlayerController ship;
    //public int[,] stages = new int[5,5];
    public Level[,] stages = new Level[5,5];
    
    private void Start()
    {
        ship.transform.position = new Vector3(playerStats.position.x,1,playerStats.position.y);        

        int count = 0;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                stages[i, j] = Levels[count];
                stages[i, j].state = playerStats.levels[count];
                count++;
            }
        }
        for (int i = 0; i < playerStats.engineLvl+1; i++)
        {
            for (int j = 0; j < playerStats.engineLvl-i+1; j++)
            {

                stages[playerStats.position.x + 2 + i, -playerStats.position.y + 2 + j].reacheable = true;
                stages[playerStats.position.x + 2 - i, -playerStats.position.y + 2 + j].reacheable = true;
                stages[playerStats.position.x + 2 + i, -playerStats.position.y + 2 - j].reacheable = true;
                stages[playerStats.position.x + 2 - i, -playerStats.position.y + 2 - j].reacheable = true;
            }
        }

        for (int i = 0; i < Quests.Count; i++)
        {
            Quests[i].isActive = playerStats.quests[i];
        }

        

    }
}
