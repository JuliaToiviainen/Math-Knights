using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class titleScreen : MonoBehaviour
{
    public Button button;
    public Button button2;
    public InputField inputField;

    void yeetButton(Button button)
    {
        Vector3 pos = button.transform.position;
        pos.x = pos.x - 550f;
        button.transform.position = pos;
    }

    void retreiveButton(Button button)
    {
        Vector3 pos = button.transform.position;
        pos.x = pos.x + 550f;
        button.transform.position = pos;
    }

    public void newGame()
    {
        SceneManager.LoadScene("LogInScene");
    }

    public void back()
    {
        retreiveButton(button);
        retreiveButton(button2);
        Vector3 pos = inputField.transform.position;
        pos.x = -550f;
        inputField.transform.position = pos;
    }

    public void beginGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void overview()
    {

    }
}
