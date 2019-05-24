using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Randall : DialogueTrigger, IDialogueEventListener
{
	public List<Dialogue> ToothPendingDialogues;
	public List<Dialogue> ToothGotDialogues;

	protected override void Start()
	{
		DialogueEventManager.RegisterListener(DialogueEvents.TOOTH_QUEST_ACCEPTED, this);
		base.Start();
	}

	public void OnEventTrigger(DialogueEvents e)
	{
		if (e == DialogueEvents.TOOTH_QUEST_ACCEPTED)
		{
			this.Dialogues = this.ToothPendingDialogues;
		}
	}

	protected override void Update()
	{
		if (InventoryUI.CurrentInstance.Has(ItemNames.MediumRareMeat))
		{
			this.Dialogues = this.ToothGotDialogues;
		}
		base.Update();
	}
}
