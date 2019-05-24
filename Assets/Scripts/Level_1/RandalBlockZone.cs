using UnityEngine;
using System.Collections;

public class RandalBlockZone : MonoBehaviour, IDialogueEventListener
{
	public Vector3 Displacement;
	public Dialogue RandalDialogue;

	public void OnEventTrigger(DialogueEvents e)
	{
		if(e == DialogueEvents.TOOTH_GIVEN)
		{
			Destroy(this.gameObject);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			DialogueUIController.CurrentInstance.SetDialogue(this.RandalDialogue);
		}
	}

	private void Start()
	{
		DialogueEventManager.RegisterListener(DialogueEvents.TOOTH_GIVEN, this);
	}
}