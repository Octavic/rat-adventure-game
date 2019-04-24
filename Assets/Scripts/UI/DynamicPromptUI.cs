using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class DynamicPromptUI : BasePromptUI
{
	public List<Text> OptionTextBoxes;

	public Dictionary<DialogueNames, DynamicDialogue> Dialogues;
	public DynamicDialogue CurrentDialogue { get; private set; }

	[Serializable]
	public struct DynamicDialogueOption
	{
		public string OptionMessage;
		public DialogueNames NextDialogue;
		public DialogueEvents EventEmitted;
	}

	[Serializable]
	public struct DynamicDialogue
	{
		/// <summary>
		/// A unique identifier for this dialogue
		/// </summary>
		public DialogueNames Name;

		/// <summary>
		/// The actual message itself
		/// </summary>
		public string Message;

		/// <summary>
		/// The list  of options that the player can choose from
		/// </summary>
		public List<DynamicDialogueOption> Options;
	}

	public void PlayDialogue(DialogueNames dialogueName)
	{
		DynamicDialogue target;
		if (!this.Dialogues.TryGetValue(dialogueName, out target))
		{
			Debug.LogError("Dialogue not found: " + dialogueName.ToString());
		}

		this.CurrentDialogue = target;
		this.PlayMessage(this.CurrentDialogue.Message);
	}

	protected override void OnCurrentMessageEnd()
	{
		for (int i = 0; i < this.CurrentDialogue.Options.Count; i++)
		{
			var option = this.CurrentDialogue.Options[i];

		}
	}

	public void OnSelectOption()
	{

	}
}
