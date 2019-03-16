using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{
    public Slider Volume;
    public AudioSource myMusic;




    // Update is called once per frame
    void Update()
    {
        NewMethod();

    }

    public void NewMethod()
    {
        myMusic.volume = Volume.value;
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
