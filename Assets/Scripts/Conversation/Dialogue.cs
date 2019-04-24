using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public struct Dialogue
{
	/// <summary>
	/// A unique identifier for this dialogue
	/// </summary>
	public string Name;

	/// <summary>
	/// The actual message itself
	/// </summary>
	public List<string> Messages;

	/// <summary>
	/// The list  of options that the player can choose from
	/// </summary>
	public List<DialogueOption> Options;
}
