using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Random;
using UnityEngine.SceneManagement;

public class enchanting : MonoBehaviour
{
    public Timer timer;
    private int answer;
    private int counter;
    private bool correct = false;
    public Text count;
    public Text display;
    public Button button;

    public Text result;

    [SerializeField]
    private Text question;

    private Text question2;

    [SerializeField]
    private InputField input;

    private int range1 = 1;
    private int range2 = 11;

    public int getCounter()
    {
        return counter;
    }

    public void GetInput(string guess)
    {
        int result;
        StartCoroutine(Check());
        Debug.Log("User entered: " + guess);
        result = int.Parse(guess);
        isCorrect(result);
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
        int a = Range(range1, range2 + 1);
        int b = Range(range1, range2 + 1);
        int c;
        if (Range(0, 3) == 0)
        {
            while (b > a)
            {
                b = Range(range1, range2);
            }
            c = a - b;
            answer = c;
            question.text = a + " - " + b + " =";
        }
        else
        {
            c = a + b;
            answer = c;
            question.text = a + " + " + b + " =";
        }
        
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
            Debug.Log(check + " true");
            result.enabled = true;
            result.text = "CORRECT";
            question.enabled = false;
            result.color = Color.green;
            yield return new WaitForSeconds(1);
        }
        else
        {
            Debug.Log(check + " false");
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
            button.onClick.Invoke();
     
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
