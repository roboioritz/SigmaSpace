using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Transform> SpawnPoint;
    public List<GameObject> EPool1;
    public List<GameObject> EPool2;

    public LevelManager Manager;
    private int amount;
    private int sec, estart,poolmax, x, y, faction, plus;
    public bool enemies;

    /*   1 (4,7,5,2,6,8,3,1) (A, B, C, D)
       -2 (5,2,4,7,3,1,6,8) (D, B, C, A)
       -3 (1,6,8,3,7,5,2,4) (C, B, A, D)
       -4 (8,3,1,6,2,4,7,5) (B, D, C, A)
       -5 (4,8,2,6,5,1,7,4) (A, D, B, C)
       -6 (5,1,7,3,4,8,2,6) (D, C, A, B)
       -7 (1,7,3,6,2,8,4,5) (C, D, A, B)
       -8 (8,2,6,3,7,1,5,4) (B, A, C, D)*/
    public struct Sec
    {
        public int[] Secuancia;
    }
    public Sec[] Secuencias;

    void Start()
    {
        SetSecValues();
        SetSeedValues();
        Random.seed = Mathf.FloorToInt (Mathf.Pow(x,5) - Mathf.Pow(y,3));
        amount = Mathf.FloorToInt((Mathf.Abs(x) + Mathf.Abs(y)) / 4 - ((Mathf.Abs(x) + Mathf.Abs(y)) % 4 / 4)) + 1;
        if (amount > 4) amount = 4;
        if (enemies)
        {
            for (int i = 0; i < amount; i++)
            {
                if (estart == 0) plus = 4; else plus = 0;
                //Debug.Log("astart: " + estart);
                if (faction == 0)
                {
                    Instantiate(EPool1[estart], SpawnPoint[Secuencias[sec].Secuancia[i] - 1 + plus].position, transform.rotation);
                }
                else
                    Instantiate(EPool2[estart], SpawnPoint[Secuencias[sec].Secuancia[i] - 1+plus].position, transform.rotation);
                Manager.asteroidCount += 1;
                Incre();
            }
        }

        //Destroy(gameObject);

    }

    void SetSecValues()
    {
        x = PlayerStats.i.destiny.x;
        y = PlayerStats.i.destiny.y;

        Secuencias = new Sec[8];
        Secuencias[0].Secuancia = new int[8];
        Secuencias[0].Secuancia[0] = 1; Secuencias[0].Secuancia[1] = 2; Secuencias[0].Secuancia[2] = 3; Secuencias[0].Secuancia[3] = 4;
        Secuencias[0].Secuancia[4] = 5; Secuencias[0].Secuancia[5] = 6; Secuencias[0].Secuancia[6] = 7; Secuencias[0].Secuancia[7] = 8;
        Secuencias[1].Secuancia = new int[8];
        Secuencias[1].Secuancia[0] = 4; Secuencias[1].Secuancia[1] = 2; Secuencias[1].Secuancia[2] = 3; Secuencias[1].Secuancia[3] = 1;
        Secuencias[1].Secuancia[4] = 8; Secuencias[1].Secuancia[5] = 6; Secuencias[1].Secuancia[6] = 7; Secuencias[1].Secuancia[7] = 5;
        Secuencias[2].Secuancia = new int[8];
        Secuencias[2].Secuancia[0] = 3; Secuencias[2].Secuancia[1] = 2; Secuencias[2].Secuancia[2] = 1; Secuencias[2].Secuancia[3] = 4;
        Secuencias[2].Secuancia[4] = 7; Secuencias[2].Secuancia[5] = 6; Secuencias[2].Secuancia[6] = 5; Secuencias[2].Secuancia[7] = 8;
        Secuencias[3].Secuancia = new int[8];
        Secuencias[3].Secuancia[0] = 2; Secuencias[3].Secuancia[1] = 4; Secuencias[3].Secuancia[2] = 3; Secuencias[3].Secuancia[3] = 1;
        Secuencias[3].Secuancia[4] = 6; Secuencias[3].Secuancia[5] = 8; Secuencias[3].Secuancia[6] = 7; Secuencias[3].Secuancia[7] = 5;
        Secuencias[4].Secuancia = new int[8];
        Secuencias[4].Secuancia[0] = 1; Secuencias[4].Secuancia[1] = 4; Secuencias[4].Secuancia[2] = 2; Secuencias[4].Secuancia[3] = 3;
        Secuencias[4].Secuancia[4] = 5; Secuencias[4].Secuancia[5] = 8; Secuencias[4].Secuancia[6] = 6; Secuencias[4].Secuancia[7] = 7;
        Secuencias[5].Secuancia = new int[8];
        Secuencias[5].Secuancia[0] = 4; Secuencias[5].Secuancia[1] = 3; Secuencias[5].Secuancia[2] = 1; Secuencias[5].Secuancia[3] = 2;
        Secuencias[5].Secuancia[4] = 8; Secuencias[5].Secuancia[5] = 7; Secuencias[5].Secuancia[6] = 5; Secuencias[5].Secuancia[7] = 6;
        Secuencias[6].Secuancia = new int[8];
        Secuencias[6].Secuancia[0] = 3; Secuencias[6].Secuancia[1] = 4; Secuencias[6].Secuancia[2] = 1; Secuencias[6].Secuancia[3] = 2;
        Secuencias[6].Secuancia[4] = 7; Secuencias[6].Secuancia[5] = 8; Secuencias[6].Secuancia[6] = 5; Secuencias[6].Secuancia[7] = 6;
        Secuencias[7].Secuancia = new int[8];
        Secuencias[7].Secuancia[0] = 2; Secuencias[7].Secuancia[1] = 1; Secuencias[7].Secuancia[2] = 3; Secuencias[7].Secuancia[3] = 4;
        Secuencias[7].Secuancia[4] = 6; Secuencias[7].Secuancia[5] = 5; Secuencias[7].Secuancia[6] = 7; Secuencias[7].Secuancia[7] = 8;

        
    }
    void SetSeedValues()
    {
        sec = Random.Range(0, 8);
        poolmax = 1 + 2 * Mathf.FloorToInt((Mathf.Abs(x) + Mathf.Abs(y)) / 6 - ((Mathf.Abs(x) + Mathf.Abs(y)) % 6 / 6));
        estart = Random.Range(0,poolmax);
        enemies = true;
        if (Mathf.Abs(x) < 4) enemies = false;
        if ((x + y) % 2 == 1) enemies = false;
        if (x < 0) faction = 0;
        if (x > 0) faction = 1;
    }

    void CalibrateStart()
    {
        if (estart > poolmax || estart > 5) estart -= 5;
        if (estart < 0) { estart = Mathf.Abs(estart); }
    }

    void Incre()
    {
        estart += Random.Range(0, 5); CalibrateStart();
    }
}


