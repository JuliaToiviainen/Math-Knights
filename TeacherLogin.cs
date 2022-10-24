using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class TeacherLogin : MonoBehaviour
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

        WWW www = new WWW("http://localhost:8888/teacher.php", form);
        yield return www;
        if (www.text[0] == '0')
        {
            Debug.Log("Admin logged in succesfully");
            DBManager.username = nameField.text;
            //DBManager.score = DBManager.score; //int.Parse(www.text.Split('\t')[1]);


            SceneManager.LoadScene("TeacherView");
        }
        else
        {
            displayText.text = "Incorrect admin login info";
            Debug.Log("Username creatation failed. Error #" + www.text);
        }
    }
}
