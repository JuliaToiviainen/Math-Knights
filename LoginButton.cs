using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class LoginButton : MonoBehaviour
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
        //form.AddField("score", DBManager.score);

        WWW www = new WWW("http://localhost:8888/register.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("User name created succesfully");
            DBManager.username = nameField.text;
            //DBManager.score = int.Parse(www.text.Split('\t')[1]);


            SceneManager.LoadScene("Tutorial");
        }
        else
        {
            displayText.text = "This username already exist, please choose a new one";
            Debug.Log("Username creatation failed. Error #" + www.text);
        }
    }
}
