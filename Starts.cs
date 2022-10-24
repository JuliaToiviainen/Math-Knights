using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Starts : MonoBehaviour
{
    public GameObject greyStar1;
    public GameObject greyStar2;
    public GameObject greyStar3;
    public GameObject yellowStar1;
    public GameObject yellowStar2;
    public GameObject yellowStar3;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("databse score " + DBManager.score);
        if (DBManager.score > 1)
        {

            greyStar1.SetActive(false);
        }
        if (DBManager.score > 5)
        {

            greyStar2.SetActive(false);
        }
        if (DBManager.score > 10)
        {

            greyStar3.SetActive(false);
        }
    }

  
    

}
