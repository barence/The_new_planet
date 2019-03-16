using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{
    public Slider Volume;

    void Start() {
        if (GameObject.Find("player") != null)
        {
            GameObject.Find("player").GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Volume != null)
        {
            PlayerPrefs.SetFloat("Volume", Volume.value);
        }
    }
}
