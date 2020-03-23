using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int num;
    public int state;
    public Button b;
    public GameObject description;
    public Image i;
    public Color selected, unselected,unobtained;
   
    void Start()
    {
        description.SetActive(false);
        
    }
    
    void Update()
    {
        switch (state)
        {
            case 0:
                i.color = unobtained;
                break;
            case 1:
                i.color = unselected;
                break;
            case 2:
                i.color = selected;
                break;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        description.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        description.SetActive(false);
    }

    /*public void Select()
    {
        i.color = selected;
    }

    public void UnSelect()
    {
        i.color = unselected;
    }

    public void Unoptained()
    {
        i.color = unobtained;
    }*/
}
