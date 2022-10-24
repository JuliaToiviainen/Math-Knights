using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class SaveProgress : MonoBehaviour
{

    public enchanting data;

    private void Awake()
    {
        //data = gameObject.AddComponent<enchanting>();
        if (DBManager.username == null)
        {
            SceneManager.LoadScene("LogInScene");
        }
        //displayUserName.text = "Player: " + DBManager.username;
        //displayScore.text = "Score: " + DBManager.score;
        
    }

    public void CallSaveGame()
    {
        StartCoroutine(SavePlayerData());
    }

    IEnumerator SavePlayerData()
    {
        WWWForm form = new WWWForm();
        DBManager.score = data.getCounter();
        Debug.Log("databse score " + DBManager.score);
        form.AddField("name", DBManager.username);
        form.AddField("score", DBManager.score);
        

        WWW www = new WWW("http://localhost:8888/saveScore.php", form);
        yield return www;
        if (www.text == "0")
        {
            //DBManager.score = int.Parse(www.text.Split('\t')[1]);
            
            Debug.Log("Game saved");
            //SceneManager.LoadScene("MapIntro");
        }
        else
        {
            Debug.Log("Game save failed. Error #" + www.text);
        }

       // DBManager.Offline();
    }
     public void ScoreCounter()
    {
        
        Debug.Log("score ");
        DBManager.score++;
        CallSaveGame();
 
    }
}
