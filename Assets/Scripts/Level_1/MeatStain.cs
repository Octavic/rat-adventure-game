using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatStain : BaseInteractable
{
	public PitZone PitZoneObject;
	public Dialogue MeatHint;

	public override void OnInteractElementalizer(Compound currentCompound)
	{
	}

	public override bool OnInteractItem(ItemUI holdingItem)
	{
		if (holdingItem == null || holdingItem.ItemName != ItemNames.MediumRareMeat)
		{
			DialogueUIController.CurrentInstance.PlayDialogue(this.MeatHint);
			return false;
		}

		StartCoroutine(PitZoneObject.PlayPitCatch());
		return true;
	}
}
