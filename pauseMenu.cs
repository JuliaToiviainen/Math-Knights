using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class pauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;
    public GameObject pauseUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gameIsPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
        
    }

    void resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void menu()
    {
        resume();
        SceneManager.LoadScene("Title");
    }

    public void quit()
    {
        Debug.Log("bye");
        Application.Quit();
    }
}
