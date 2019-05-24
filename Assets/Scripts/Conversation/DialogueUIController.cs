using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogueUIController : MonoBehaviour
{
	public DialogueUI DialogueUIPrefab;

	public static DialogueUIController CurrentInstance
	{
		get
		{
			if (currentInstance == null)
			{
				currentInstance = GameObject.FindObjectOfType<DialogueUIController>();
			}
			return currentInstance;
		}
	}
	private static DialogueUIController currentInstance;

	private Dictionary<string, Dialogue> HashedDialogues;

	private DialogueUI currentDialogueUI;

	public void SetDialogue(Dialogue d)
	{
		this.SetDialogues(new List<Dialogue>() { d });
	}

	public void SetDialogues(List<Dialogue> dialogues, string startingDialogue = null)
	{
		if (startingDialogue == null)
		{
			startingDialogue = dialogues[0].Name;
		}

		this.HashedDialogues = dialogues.ToDictionary(dialogue => dialogue.Name);
		this.PlayDialogue(startingDialogue);
	}

	public void PlayDialogue(string dialogueName)
	{
		Dialogue targetDialogue;
		if(!this.HashedDialogues.TryGetValue(dialogueName, out targetDialogue))
		{
			Debug.LogError("Dialogue name not found: " + dialogueName);
		}

		this.PlayDialogue(targetDialogue);
	}

	public void PlayDialogue(Dialogue dialogue)
	{
		if (this.currentDialogueUI != null)
		{
			Destroy(this.currentDialogueUI.gameObject);
		}

		this.currentDialogueUI = Instantiate(this.DialogueUIPrefab, InputController.MainCanvas.transform);
		this.currentDialogueUI.PlayDialogue(dialogue);
	}

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{

	}
}
