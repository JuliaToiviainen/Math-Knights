using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class LoadUserName : MonoBehaviour
{
    public Text displayUserName;

    private void Awake()
    {
        if (DBManager.username == null)
        {
            //SceneManager.LoadScene("LogInScene");
        }
        displayUserName.text = DBManager.username;
    }

    public void CallSaveGame()
    {
        StartCoroutine(SavePlayerData());
    }

    IEnumerator SavePlayerData()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", DBManager.username);

        WWW www = new WWW("http://localhost:8888/register.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("Game saved");
            //SceneManager.LoadScene("MapIntro");
        }
        else
        {
            Debug.Log("Game save failed. Error #" + www.text);
        }

        DBManager.Offline();
        SceneManager.LoadScene("LogInScene");
    }
}
