using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burner : BaseInteractable
{
	public ItemUI MediumRareMeat;

	public Dialogue NeedFire;

	private Animator AnimatorComp;
	private bool isBurning;

	public override void OnInteractElementalizer(Compound currentCompound)
	{
		if (currentCompound == null)
		{
			return;
		}

		if (currentCompound.CompoundName == CompoundNames.Oxygen)
		{
			this.isBurning = true;
			this.AnimatorComp.SetBool("IsBurning", true);
		}
		if (currentCompound.CompoundName == CompoundNames.Water)
		{
			this.isBurning = false;
			this.AnimatorComp.SetBool("IsBurning", false);
		}
	}

	public override bool OnInteractItem(ItemUI holdingItem)
	{
		if (holdingItem == null || !this.isBurning)
		{
			DialogueUIController.CurrentInstance.PlayDialogue(this.NeedFire);
			return false;
		}

		if (holdingItem.ItemName == ItemNames.Meat)
		{
			InventoryUI.CurrentInstance.TryAddItem(this.MediumRareMeat);
			return true;
		}

		return false;
	}

	protected override void Start()
	{
		this.AnimatorComp = this.GetComponent<Animator>();
		base.Start();
	}
}
