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
			DialogueUIController.CurrentInstance.SetDialogues(new System.Collections.Generic.List<Dialogue>() { this.RandalDialogue });
		}
	}

	private void Start()
	{
	}
}