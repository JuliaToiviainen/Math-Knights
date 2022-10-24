using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputAnswer : MonoBehaviour
{
    [SerializeField]
    private InputField input;

    public void GetInput(string guess)
    {
        Debug.Log("User entered: " + guess);
        input.text = "";
    }

}
