using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MisionCompletion : MonoBehaviour
{
    public static MisionCompletion i;
    public Text Text;
    public GameObject box;

    void Start()
    {
        i = this;
    }

    public void Completed(string txt)
    {
        Text.text = txt;
        box.SetActive(true);
    }

    public void Continuar()
    {
        box.SetActive(false);
        Misiones.i.MisionAmount();
    }

}
