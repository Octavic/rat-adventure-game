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

	
	public List<DialogueMessage> Messages;

	/// <summary>
	/// The list  of options that the player can choose from
	/// </summary>
	public List<DialogueOption> Options;
}
