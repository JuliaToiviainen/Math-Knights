using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;


public class Scoreboard : MonoBehaviour
{
    public Text displayTop1User;
    public Text displayTop1Score;



     public void CallTopScores()
     {
         StartCoroutine(ScoresData());
     }

     IEnumerator ScoresData()
     {
         WWWForm form = new WWWForm();
        // form.AddField("name", DBManager.username);
        // form.AddField("score", DBManager.score);


         WWW www = new WWW("http://localhost:8888/topScores.php", form);

         yield return www;

         if (www.text[0] == '0')
          {

            Debug.Log("Scores found");

            string[] scores = www.text.Split('\t');
            string value1 = scores[0];
            //string value2 = scores[1];
            displayTop1User.text = value1;
            //displayTop1Score.text = value2;

            //string value3 = scores[0];
            //displaTop1Score.text = "best one " + value1;
            Debug.Log("best one " + value1);
   
         }
         else
         {
             Debug.Log("Scores not found. Error #" + www.text);
         }

         DBManager.Offline();
         SceneManager.LoadScene("Title");
     }



}
