using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePlayerController : MonoBehaviour
{
    public PlayerStats playerStats;

    public bool moving;
    public Vector2Int departure;
    public int engine;
    public Vector2Int moveCount;

    void Start()
    {        
        transform.position = new Vector3(playerStats.position.x,1, playerStats.position.y);
        departure = playerStats.position;
        engine = playerStats.engineLvl;
    }
    
    void Update()
    {
        Move();
    }

    public void Move()
    {
        //&& Mathf.Abs(moveCount.x) + Mathf.Abs(moveCount.y) + 1 * Mathf.Sign(Input.GetAxis("Horizontal")) * Mathf.Sign(moveCount.x) < engine + 1 
                                                        //&& Mathf.Abs(departure.x) + Mathf.Abs(moveCount.x) + 1 * Mathf.Sign(Input.GetAxis("Horizontal")) * Mathf.Sign(moveCount.x) < 3)

        if (!moving && Input.GetAxis("Vertical1") != 0 && + Mathf.Abs(moveCount.x + 1 * Mathf.Sign(-Input.GetAxis("Vertical1"))) + Mathf.Abs(moveCount.y) < engine+1
                                                        && Mathf.Abs(departure.x) + Mathf.Abs(moveCount.x + 1 * Mathf.Sign(-Input.GetAxis("Vertical1")))  < 3) //Este 3 en el futuro sera el limite del mapa +1
        {
            moving = true;
            StartCoroutine(Moving());
            moveCount.x += Mathf.RoundToInt(1 * Mathf.Sign(-Input.GetAxis("Vertical1")));
            transform.rotation = Quaternion.Euler(0,-90 * Mathf.Sign(-Input.GetAxis("Vertical1")),0);
        }
        if (!moving && Input.GetAxis("Horizontal1") != 0 && +Mathf.Abs(moveCount.x ) + Mathf.Abs(moveCount.y + 1 * Mathf.Sign(-Input.GetAxis("Horizontal1"))) < engine + 1
                                                      && Mathf.Abs(departure.y) + Mathf.Abs(moveCount.y + 1 * Mathf.Sign(-Input.GetAxis("Horizontal1"))) < 3)
        {
            moving = true;
            StartCoroutine(Moving());
            moveCount.y += Mathf.RoundToInt(1 * Mathf.Sign(-Input.GetAxis("Horizontal1")));
            transform.rotation = Quaternion.Euler(0, 90 + 90 * Mathf.Sign(-Input.GetAxis("Horizontal1")), 0);
        }
        if (moving) transform.Translate(2*Time.deltaTime,0,0);
        if (!moving && Input.GetAxis("Fuel1") != 0)
        {
            //SceneManager.LoadScene("["+ (departure.x + moveCount.x).ToString() +"][" + (departure.y + moveCount.y).ToString() + "]");
            SceneManager.LoadScene("Pruebas sector");
            PlayerStats.i.destiny = new Vector2Int(departure.x - moveCount.x, departure.y - moveCount.y);
        }
    }

    IEnumerator Moving()
    {
        yield return new WaitForSeconds(0.5f);
        moving = false;
    }

}
