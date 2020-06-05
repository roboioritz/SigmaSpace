using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSudio : MonoBehaviour
{
    public AudioSource ASource;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton ()
    {
        ASource.Play();
    }

}
