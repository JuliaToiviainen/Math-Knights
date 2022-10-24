using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackButton : MonoBehaviour
{
    public void GoBackToLogin()
    {
        SceneManager.LoadScene("LogInScene");
    }

    public void GoBackToMapIntro()
    {
        SceneManager.LoadScene("MapIntro");
    }

    public void GoBackToMap()
    {
        SceneManager.LoadScene("Map1");
    }
}
