using UnityEngine;
using System.Collections;

public class RandalBlockZone : MonoBehaviour, IDialogueEventListener
{
	public Vector3 Displacement;
	public Dialogue RandalDialogue;

	private DialogueUI dialogueUI;

	public void OnSelectDialogueOption(DialogueOption option)
	{
		var eventEmitted = option.EventEmitted;
		if (eventEmitted == DialogueEvents.DIALOGUE_END)
		{
			PlayerController.CurrentInstance.transform.position += this.Displacement;
		}

		if (eventEmitted == DialogueEvents.TOOTH_GIVEN)
		{
			Destroy(this.gameObject);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			var dialogueUI = Instantiate(PrefabManager.CurrentInstance.PlayerPrompt, InputController.MainCanvas.transform);
			dialogueUI.PlayDialogue(this.RandalDialogue);
		}
	}

	private void Start()
	{
		DialogueEventManager.RegisterListener(this);
	}
}