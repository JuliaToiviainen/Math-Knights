using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUI : MonoBehaviour
{
    public GameObject continueButton;

    void Start()
    {
        continueButton.SetActive(false);
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            continueButton.SetActive(true);
        }
    }

    void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            continueButton.SetActive(false);
        }
    }
}



