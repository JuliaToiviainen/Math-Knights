using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ViewLevelsAppear : MonoBehaviour
{
    public GameObject panel;

    public void Start()
    {
        panel.SetActive(false);
    }
    public void ShowPanel()
    {
        panel.SetActive(true);
    }
    public void HidePanel()
    {
        panel.SetActive(false);
    }
    

}
