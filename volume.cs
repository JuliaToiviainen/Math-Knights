using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class volume : MonoBehaviour
{
    [SerializeField] Slider slider;

    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume")){
            PlayerPrefs.SetFloat("musicVolume", 1);
            load();
        }
        else
        {
            load();
        }
    }

    
    public void changeVolume()
    {
        AudioListener.volume = slider.value;
        save();
    }

    private void save()
    {
        PlayerPrefs.SetFloat("musicVolume", slider.value);
    }

    private void load()
    {
        slider.value = PlayerPrefs.GetFloat("musicVolume");
    }
}
