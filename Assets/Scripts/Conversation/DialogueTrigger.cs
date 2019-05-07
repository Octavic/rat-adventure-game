using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A simple message board that displays a message when interacted with
/// When given multiple messages, each will take up its own screen (For possible comedic effect)
/// </summary>
public class DialogueTrigger : BaseInteractable, IDialogueEventListener
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
		this.PlayDialogue(this.Dialogues[0]);
		return false;
	}

	/// <summary>
	/// Do nothing
	/// </summary>
	public override void OnInteractElementalizer(Compound currentCompound)
	{
	}

	public void OnSelectDialogueOption(DialogueOption option)
	{
		// TODO: Emit events here

		var nextDialogue = option.NextDialogue;
		if (string.IsNullOrEmpty(nextDialogue))
		{
			Destroy(this.DialogueUI.gameObject);
		}
		else
		{
			Dialogue targetDialogue;
			if (!this.HashedDialogues.TryGetValue(nextDialogue, out targetDialogue))
			{
				Debug.LogError("Invalid dialogue name from option: " + nextDialogue);
			}

			this.PlayDialogue(targetDialogue);
		}
	}

	protected override void Start()
	{
		foreach (var dialogue in this.Dialogues)
		{
			var dialogueName = dialogue.Name;
			if (this.HashedDialogues.ContainsKey(dialogueName))
			{
				Debug.LogError("Duplicate dialogue name: " + dialogueName);
			}

			this.HashedDialogues[dialogueName] = dialogue;
		}

		this.interactableUI.SetMessage("Talk", true);
		this.interactableUI.SetMessage(null, false);

		base.Start();
	}

	private void PlayDialogue(Dialogue dialogue)
	{
		if (this.DialogueUI != null)
		{
			Destroy(this.DialogueUI.gameObject);
			this.DialogueUI.gameObject.SetActive(false);
		}

		this.DialogueUI = Instantiate(PrefabManager.CurrentInstance.PlayerPrompt, InputController.MainCanvas.transform);
		this.DialogueUI.Listeners.Add(this);
		this.DialogueUI.PlayDialogue(dialogue);
	}
}
