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
	private DialogueUI UI;

	/// <summary>
	/// Dialogues hashed with their name
	/// </summary>
	private Dictionary<string, Dialogue> HashedDialogues = new Dictionary<string, Dialogue>();

	/// <summary>
	/// Called when the user interacts with this object
	/// </summary>
	public override void OnInteract()
	{
		this.PlayDialogue(this.Dialogues[0]);
	}

	public void OnSelectDialogueOption(DialogueOption option)
	{
		// TODO: Emit events here

		var nextDialogue = option.NextDialogue;
		if (string.IsNullOrEmpty(nextDialogue))
		{
			Destroy(this.UI.gameObject);
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
		base.Start();
	}

	private void PlayDialogue(Dialogue dialogue)
	{
		if (this.UI != null)
		{
			Destroy(this.UI.gameObject);
			this.UI.gameObject.SetActive(false);
		}

		this.UI = Instantiate(PrefabManager.CurrentInstance.PlayerPrompt, InputController.MainCanvas.transform);
		this.UI.Listeners.Add(this);
		this.UI.PlayDialogue(dialogue);
	}
}
