using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    static public LevelManager i;
    static public Vector3 posP1;
    static public Vector3 posP2;
    public GameObject Player1;
    public GameObject Player2;
    public bool start = false;
    public int asteroidCount;

    public static bool twoPlayers = false;
    
    void Start()
    {
        i = this;
        Instantiate(Player1, transform.position, Quaternion.identity);
    }
   
    void Update()
    {
        posP1 = Player1.transform.position;
        if(twoPlayers) posP2 = Player2.transform.position;

        if (!twoPlayers && Input.GetKeyDown(KeyCode.Return))
        {
            twoPlayers = true;
            Instantiate(Player2, transform.position, Quaternion.identity);
        }
        if (asteroidCount == 0 && start)
        {
            //playsound victori
            PlayerStats.i.position = PlayerStats.i.destiny;
            StartCoroutine(Back());
        }
    }

    public void GetStart()
    {
        start = true;
    }

    public void End()
    {
        StartCoroutine(Back());
    }

    public void Add()
    {
        asteroidCount++;
    }

    public void Remove()
    {
        asteroidCount--;
    }

    IEnumerator Back()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("LevelScene");
    }



}
