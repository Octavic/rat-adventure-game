using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A simple message board that displays a message when interacted with
/// When given multiple messages, each will take up its own screen (For possible comedic effect)
/// </summary>
public class MessageBoard : BaseInteractable
{
	public List<string> Messages;

	public override void OnInteract()
	{
		Debug.Log(Messages[0]);
	}

}
