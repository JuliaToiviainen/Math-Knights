using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public Slider timeBar;
    public Text timeText;
    public float timeFloat;
    private bool stop = false;
    float count;
    private int min;
    private int sec;

    void Start()
    {
        stop = false;
        timeBar.maxValue = timeFloat;
        timeBar.value = timeFloat;
    }
    public bool getStop()
    {
        return stop;
    }
    void Update()
    {
        count = timeFloat - Time.timeSinceLevelLoad;
        min = Mathf.FloorToInt(count / 60);
        sec = Mathf.FloorToInt(count - min * 60f);

        string timeText2 = string.Format("{0:0}:{1:00}", min, sec);
        if(count <= 0)
        {
            stop = true;
        }
        if (stop == false)
        {
            timeText.text = timeText2;
            timeBar.value = count;
        }
    }
    public float GetTime()
    {
        return count;
    }
}
