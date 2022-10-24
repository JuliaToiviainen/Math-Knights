using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScene : MonoBehaviour
{

    public void LoadLoadingScene()
    {
        SceneManager.LoadScene("EnchantMenuLevel1");
    }
    public void LoadLoadingScene2()
    {
        SceneManager.LoadScene("EnchantMenuLevel2");
    }
    public void LoadLoadingMap()
    {
        SceneManager.LoadScene("Map1");
        
    }
}
