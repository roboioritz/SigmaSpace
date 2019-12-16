﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePlayerController : MonoBehaviour
{
    public bool moving;
    public Vector2Int departure;
    public int engine;
    public Vector2Int moveCount;

    private bool paused;
    private bool shopopen;

    void Start()
    {
        Time.timeScale = 1f;
        transform.position = new Vector3(PlayerStats.i.position.x, 0.1f, PlayerStats.i.position.y);
        departure = PlayerStats.i.position;
        engine = PlayerStats.i.engineLvl;
    }
    
    void Update()
    {
        if (!paused)
        {
            Move();
            if (Input.GetButtonDown("Start1"))
            {
                paused = true;
                Ui_controller.i.pause.SetActive(true);
                Time.timeScale = 0f;
            }
            if (!shopopen)
            {
                if (Input.GetButtonDown("Fuel1"))
                {
                    shopopen = true;
                    Ui_controller.i.shop.SetActive(true);
                    Time.timeScale = 0f;
                }
            }
            else if (Input.GetButtonDown("Fuel1"))
            {
                shopopen = false;
                Ui_controller.i.shop.SetActive(false);
                Time.timeScale = 1f;
            }
        }
        else if (Input.GetButtonDown("Start1"))
        {
            paused = false;
            Ui_controller.i.pause.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void Move()
    {
        //&& Mathf.Abs(moveCount.x) + Mathf.Abs(moveCount.y) + 1 * Mathf.Sign(Input.GetAxis("Horizontal")) * Mathf.Sign(moveCount.x) < engine + 1 
        //&& Mathf.Abs(departure.x) + Mathf.Abs(moveCount.x) + 1 * Mathf.Sign(Input.GetAxis("Horizontal")) * Mathf.Sign(moveCount.x) < 3)
        //departure.y + moveCount.y + 1 * Mathf.Sign(-Input.GetAxis("Vertical1"))
        if (!moving && Input.GetAxis("Vertical1") != 0 && + Mathf.Abs(moveCount.y + 1 * Mathf.Sign(-Input.GetAxis("Vertical1"))) + Mathf.Abs(moveCount.x) < engine+1
                                                        && departure.y + moveCount.y + 1 * Mathf.Sign(-Input.GetAxis("Vertical1")) < 100
                                                        && departure.y + moveCount.y + 1 * Mathf.Sign(-Input.GetAxis("Vertical1")) > -100)//Este 3 en el futuro sera el limite del mapa +1
        {
            moving = true;
            StartCoroutine(Moving());
            moveCount.y += Mathf.RoundToInt(1 * Mathf.Sign(-Input.GetAxis("Vertical1")));
            transform.rotation = Quaternion.Euler(0,-90 * Mathf.Sign(-Input.GetAxis("Vertical1")),0);
        }
        if (!moving && Input.GetAxis("Horizontal1") != 0 && +Mathf.Abs(moveCount.y ) + Mathf.Abs(moveCount.x + 1 * Mathf.Sign(Input.GetAxis("Horizontal1"))) < engine + 1
                                                      && departure.x + moveCount.x + 1 * Mathf.Sign(Input.GetAxis("Horizontal1")) < 300
                                                        && departure.x + moveCount.x + 1 * Mathf.Sign(Input.GetAxis("Horizontal1")) > -300)
        {
            moving = true;
            StartCoroutine(Moving());
            moveCount.x += Mathf.RoundToInt(1 * Mathf.Sign(Input.GetAxis("Horizontal1")));
            transform.rotation = Quaternion.Euler(0, 90 + 90 * Mathf.Sign(-Input.GetAxis("Horizontal1")), 0);
        }       

        if (moving) transform.Translate(2*Time.deltaTime,0,0);

        if (!moving && Input.GetAxis("Fire1") != 0)
        {
            SceneManager.LoadScene("["+ (departure.x + moveCount.x).ToString() +"][" + (departure.y + moveCount.y).ToString() + "]");
            //SceneManager.LoadScene("Pruebas sector");
            PlayerStats.i.destiny = new Vector2Int(departure.x + moveCount.x, departure.y + moveCount.y);
        }
    }

    IEnumerator Moving()
    {
        yield return new WaitForSeconds(0.5f);
        moving = false;
        transform.position = new Vector3Int(departure.x + moveCount.x, 0, departure.y + moveCount.y);
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Contine()
    {
        paused = false;
        Ui_controller.i.pause.SetActive(false);
        Time.timeScale = 1f;
    }

}
