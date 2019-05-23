using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public struct DialogueMessage
{
	/// <summary>
	/// Prefab for the portrait
	/// </summary>
	public GameObject PortraiPrefab;

	/// <summary>
	/// The actual message itself
	/// </summary>
	public string Message;
}

[Serializable]
public struct Dialogue
{
	/// <summary>
	/// A unique identifier for this dialogue
	/// </summary>
	public string Name;

	/// <summary>
	/// A list of all messages
	/// </summary>
	public List<DialogueMessage> Messages;

	/// <summary>
	/// What event to emit when player chooses this option
	/// </summary>
	public DialogueEvents EventEmitted;

	/// <summary>
	/// The next dialogue to be played. If none, then we return
	/// </summary>
	public string NextDialogue;

	/// <summary>
	/// The list  of options that the player can choose from
	/// </summary>
	public List<DialogueOption> Options;
}
