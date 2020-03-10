using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelArrayStats 
{
    [System.Serializable]
    public struct levels
    {
        public int[] X;
    }
    public levels[] Y = new levels[25];
}
