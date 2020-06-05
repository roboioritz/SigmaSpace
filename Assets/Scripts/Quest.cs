using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public int state; //0 inactive; 1 active; 2 completed; 3 failed;
    public int num;
    public int award; //0 nada; n objeto;
    public List<Level> levels;
    public List<Quest> Activate;
    public List<Quest> Fail;
    public string Name;
    public string description;
    public string completion;

    
   

    void Start()
    {
        state = PlayerStats.i.Quests[num];
        Init();


    }
    
    void Update()
    {
        Init();
        //PlayerStats.i.Quests[num] = state;        
    }

    private bool Comprobar()
    {
        bool ok = true;

        foreach (Level l in levels)
        {
            if (l.state != 2) ok = false;
        }
        Debug.Log("" + num + "  " + ok);
        return ok;
    }

    private void Completed()
    {
        if (award != 0 && award != 1) PlayerStats.i.QuestAward(award);
        if (award == 1) PlayerStats.i.laserLvl++;
        MisionCompletion.i.Completed(completion);
        state = 2;
        PlayerStats.i.Quests[num] = state;
        if (Activate.Count > 0) { foreach (Quest q in Activate) { q.state = 1; PlayerStats.i.Quests[q.num] = 1; q.Init(); } }
        if (Fail.Count > 0) { foreach (Quest q in Fail) { q.state = 2; PlayerStats.i.Quests[q.num] = 2; } }
        Debug.Log("Completed");
    }

    public void Init()
    {
        if (state == 1)
        {
            if (Comprobar())
            {
                Completed();
            }

            Debug.Log("start");
            foreach (Level l in levels)
            {
                if (l.state != 2) { l.marco.SetActive(true); }
                else l.marco.SetActive(false);
            }            
        }
    }
}
