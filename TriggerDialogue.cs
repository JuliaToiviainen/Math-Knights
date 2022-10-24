using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
	private bool started = false;
	public Dialogue dialogue;

	public void StartDialogue()
	{
		FindObjectOfType<Talk>().LoadDialogue(dialogue);
		started = true;
		FindObjectOfType<Talk>().StartDialogue();

	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0) && started == true)
		{
			FindObjectOfType<Talk>().StartDialogue();
		}
	}

	public void stopDialogue(bool started2)
    {
		started = started2;
	}

}