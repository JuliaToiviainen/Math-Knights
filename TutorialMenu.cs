using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialMenu : MonoBehaviour
{
    private bool moveNow = false;
    public Animator animator;
    public TriggerDialogue triggerDialogue;
    public Button button;

    private Vector3 holding;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform child;

    [SerializeField]
    private Transform child2;

    private Queue<string> talk;

    // Start is called before the first frame update
    public void Start()
    {
        talk = new Queue<string>();
    }
    public void tutorialStart()
    {
        Debug.Log("tutorial");
        animator.SetTrigger("EnterNPC");
        button.enabled = false;
        GameObject.Find("Button").GetComponentInChildren<Text>().text = "";
        MoveInto();
    }

        public void MoveInto()
    {
        Debug.Log("moving");
        holding = (child2.localPosition - child.position).normalized;
        move();
    }

    public void move()
    {
        moveNow = true;
        Update();
    }


    // Update is called once per frame
    void Update()
    {
        if (moveNow == true)
        {
            if (child.position.x <= child2.position.x)
            {
                child.position += holding * speed * Time.deltaTime;
            }
        }
    }
}