using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asteroidex : MonoBehaviour
{
    public GameObject i;
    public List<Sprite> Images;
    public List<string> Texts;
    public List<string> Names;
    public int page = 0;
    public Image I;
    public Text T;
    public Text N;
    public Animator ani;

    void Start()
    {
        
    }
    
    void Update()
    {
        I.sprite = Images[page];
        T.text = Texts[page];
        N.text = Names[page];
    }

    public void Left()
    {
        page--;
        if (page < 0) page = 14;
    }

    public void Right()
    {
        page++;
        if (page > 14) page = 0;
    }   

    public void Return()
    {
        ani.SetTrigger("out");
        StartCoroutine(Out());
    }

    IEnumerator Out()
    {
        yield return new WaitForSeconds(0.51f);
        i.SetActive(false);
    }

}
