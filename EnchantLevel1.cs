using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Random;
using UnityEngine.SceneManagement;

public class EnchantLevel1 : MonoBehaviour
{
    public Timer timer;
    private int answer;
    private int counter;
    private bool correct = false;
    public Text count;
    public Text display;
    

    public Text result;

    [SerializeField]
    private Text question;

    private Text question2;

    [SerializeField]
    private InputField input;

    public int Counter()
    {
        return counter;
    }

    public void GetInput(string guess)
    {
        StartCoroutine(Check());
        Debug.Log("User entered: " + guess);
        isCorrect(int.Parse(guess));
        input.text = "";
    }

    public IEnumerator WaitForInputActivation()
    {
        yield return 0;
        input.ActivateInputField();
    }

    void Update()
    {
        StartCoroutine(Check());
    }

    void Awake()
    {
        StartCoroutine(WaitForInputActivation());
        StartCoroutine(Check());
        int a = Range(1, 11);
            int b = Range(1, 11);
            int c = a + b;
            answer = c;

            question.text = a + " + " + b + " =";
            question2 = question;
            Debug.Log(a + "," + b + "," + answer);
    }

    public IEnumerator Check()
    {
        bool check = timer.getStop();
        if (check == true)
        {
            Debug.Log("Times up");
            timer.timeBar.enabled = false;
            timer.timeText.enabled = false;
            question.enabled = false;
            result.enabled = true;
            result.text = "TIMES UP";
            result.color = Color.yellow;
            display.enabled = false;
            count.enabled = true;
            count.text = "YOU GOT " + counter.ToString() + " QUESTIONS!";
            yield return new WaitForSeconds(2);
            check = false;
            SceneManager.LoadScene("BattleScence1");
        }
    }

    public int GetCounter()
    {
        return int.Parse(count.text);
    }

    public int GetCounter2()
    {
        return counter;
    }

    public void ShiftColor(bool check)
    {
        StartCoroutine(ColorShift(check));
    }

    public IEnumerator ColorShift(bool check)
    {
        
        if (correct == true)
        {
            Debug.Log("true");
            result.enabled = true; 
            result.text = "CORRECT";
            question.enabled = false;
            result.color = Color.green;
            yield return new WaitForSeconds(1);
        }
        else
        {
            Debug.Log("false");
            result.enabled = true;
            result.text = "TRY AGAIN";
            question.enabled = false;
            result.color = Color.red;
            yield return new WaitForSeconds(1);
        }
        result.enabled = false;
        question.enabled = true;
        question.color = Color.white;
    }

    void isCorrect(int guess)
    {
        StartCoroutine(Check());
        if (guess == answer)
        {
            correct = true;
            ShiftColor(correct);

            counter++;

            Awake();

        }
        else
        {
            correct = false;
            ShiftColor(correct);

            Debug.Log("Incorrect it should be: " + answer);

            StartCoroutine(WaitForInputActivation());
            question = question2;


        }
    }
}
