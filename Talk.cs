using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Talk : MonoBehaviour
{
    private Queue<string> sentences;
    public Text text;
    public Button yes;
    public Button no;

    private int count;
    private bool skip = false;
    public TriggerDialogue triggerDialogue;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        hideButtons();
    }

    void hideButtons()
    {
        yes.enabled = false;
        GameObject.Find("no").GetComponentInChildren<Text>().text = "";
        no.enabled = false;
        GameObject.Find("yes").GetComponentInChildren<Text>().text = "";
    }

    private void Update()
    {
        
    }

    public void LoadDialogue(Dialogue dialogue)
    {
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
    }

    public void StartDialogue()
    {
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        triggerDialogue.stopDialogue(false);
        string sentence2 = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence2));
    }

    IEnumerator TypeSentence(string sentence3)
    {

        float wait = 0.05f;

        count++;

        Debug.Log(count);
        text.text = "";

        foreach (char letter in sentence3.ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(wait);
        }

        triggerDialogue.stopDialogue(true);

        if (count == 2)
        {
            Debug.Log("buttons");
            skipTutorial();
        }

        if (skip == true)
        {
            SceneManager.LoadScene("MapIntro");
        }

        if (count == 11)
        {
            SceneManager.LoadScene("EnchantMenu");
        }
    }
    public void skipTutorial()
    {
        triggerDialogue.stopDialogue(false);
        yes.enabled = true;
        GameObject.Find("no").GetComponentInChildren<Text>().text = "no";
        no.enabled = true;
        GameObject.Find("yes").GetComponentInChildren<Text>().text = "yes";
    }

    public void noSkip()
    {
        hideButtons();
        StartCoroutine(TypeSentence("Good luck then!"));
        skip = true;
    }

    public void yesSkip()
    {
        hideButtons();
        skip = false;
        FindObjectOfType<Talk>().StartDialogue();
        triggerDialogue.stopDialogue(true);
    }
}
