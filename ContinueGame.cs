using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;


public class ContinueGame : MonoBehaviour
{
    public InputField nameField;
    public Button submitButton;
    public Text displayText;

    public void CallLogin()
    {
        StartCoroutine(Login());
    }

    IEnumerator Login()
    {

        WWWForm form = new WWWForm();
  
        form.AddField("name", nameField.text);

        WWW www = new WWW("http://localhost:8888/continue.php", form);

        yield return www;


         if (www.text[0] == '0') 
         {
            string[] results = www.text.Split('\t');
            Debug.Log("User logged in succesfully");
            DBManager.username = nameField.text;
            DBManager.score = int.Parse(results[0]);
  

              Debug.Log("score " + DBManager.score);

              SceneManager.LoadScene("Map1");
        }
        else
        {
            displayText.text = "This username doesn't exist. Please try again or choose a new game";
            Debug.Log("Username creatation failed. Error #" + www.text);
        }
    }
}
