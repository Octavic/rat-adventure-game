using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatStain : BaseInteractable
{
	public PitZone PitZoneObject;
	public Dialogue MeatHint;
	public Dialogue RawMeatHint;

	public override void OnInteractElementalizer(Compound currentCompound)
	{
	}

	public override bool OnInteractItem(ItemUI holdingItem)
	{
		if (holdingItem != null)
		{
			if (holdingItem.ItemName == ItemNames.RawMeat)
			{
				DialogueUIController.CurrentInstance.PlayDialogue(this.RawMeatHint);
				return false;
			}
			else if (holdingItem.ItemName == ItemNames.MediumRareMeat)
			{
				StartCoroutine(PitZoneObject.PlayPitCatch());
				return true;
			}
		}

		DialogueUIController.CurrentInstance.PlayDialogue(this.MeatHint);
		return false;
	}
}
