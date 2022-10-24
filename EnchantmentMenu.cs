using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnchantmentMenu : MonoBehaviour
{


    public void EnchantStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void EnchantContinue()
    {
        SceneManager.LoadScene("ContinueGame");
    }
    public void EnchantViewScores()
    {
        SceneManager.LoadScene("ViewScores");
    }
    public void EnchantAdmin()
    {
        SceneManager.LoadScene("TeacherLogin");
    }
}
