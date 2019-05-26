using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harry : DialogueTrigger, IDialogueEventListener
{
	public List<Dialogue> ElementalizerExplaination;

	public void OnEventTrigger(DialogueEvents e)
	{
		this.Dialogues = this.ElementalizerExplaination;
	}

	protected override void Start()
	{
		DialogueEventManager.RegisterListener(DialogueEvents.ELEMENTALIZER_GIVEN, this);
		base.Start();
	}
}
