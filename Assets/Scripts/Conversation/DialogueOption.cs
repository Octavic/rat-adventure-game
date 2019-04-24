using UnityEngine;
using System.Collections;
using System;

[Serializable]
public struct DialogueOption
{
	/// <summary>
	/// Display message for the option
	/// </summary>
	public string OptionMessage;

	/// <summary>
	/// The dialogue that should play next
	/// </summary>
	public string NextDialogue;

	/// <summary>
	/// What event to emit when player chooses this option
	/// </summary>
	public DialogueEvents EventEmitted;
}