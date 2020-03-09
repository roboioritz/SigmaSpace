using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class LevelArray
{
    [System.Serializable]

    public struct levels
    {
        
        public Level[] level;
    }
    public levels[] levellist = new levels[25];

}
