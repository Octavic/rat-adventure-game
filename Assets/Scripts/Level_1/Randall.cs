using UnityEngine;
using System.Collections;

public class Randall : DialogueTrigger, IDialogueEventListener
{
	protected override void Start()
	{
		DialogueEventManager.RegisterListener(DialogueEvents.TOOTH_QUEST_ACCEPTED, this);
		base.Start();
	}

	public void OnEventTrigger(DialogueEvents e)
	{
		if(e == DialogueEvents.TOOTH_QUEST_ACCEPTED)
		{

		}
	}
}
