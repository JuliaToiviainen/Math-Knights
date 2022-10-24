using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchButton : MonoBehaviour
{
    public GameObject continuePanel;

    void Start()
    {
        continuePanel.SetActive(false);
    }

    void OnCollisionEnter2D (Collision2D Colider)
    {

        if (Colider.gameObject.name == "HeroKnight")
        {
            continuePanel.SetActive(true);
            Debug.Log("Ready for game");

        }
    }
}
