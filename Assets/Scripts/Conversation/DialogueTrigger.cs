using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A simple message board that displays a message when interacted with
/// When given multiple messages, each will take up its own screen (For possible comedic effect)
/// </summary>
public class DialogueTrigger : BaseInteractable
{
	/// <summary>
	/// A collection of dialogues
	/// </summary>
	public List<Dialogue> Dialogues;

	/// <summary>
	/// The current prompt
	/// </summary>
	private DialogueUI DialogueUI;

	/// <summary>
	/// Dialogues hashed with their name
	/// </summary>
	private Dictionary<string, Dialogue> HashedDialogues = new Dictionary<string, Dialogue>();

	/// <summary>
	/// Called when the user interacts with this object
	/// </summary>
	public override bool OnInteractItem(ItemUI holdingItem)
	{
		DialogueUIController.CurrentInstance.SetDialogues(this.Dialogues);
		return false;
	}

	/// <summary>
	/// Do nothing
	/// </summary>
	public override void OnInteractElementalizer(Compound currentCompound)
	{
	}
}
