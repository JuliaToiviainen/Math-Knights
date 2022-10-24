using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Text text;
    public Text text2;
    private bool fadeEnd = false;

    void Start()
    {
        StartCoroutine(FadeText(2f, text,text2));
    }

    public IEnumerator FadeText(float t, Text i, Text i2)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        i2.color = new Color(i2.color.r, i2.color.g, i2.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            i2.color = new Color(i2.color.r, i2.color.g, i2.color.b, i2.color.a + (Time.deltaTime / t));
            yield return null;
        }
        fadeEnd = true;
    }
    public bool stopFade()
    {
        return fadeEnd;
    }
}
