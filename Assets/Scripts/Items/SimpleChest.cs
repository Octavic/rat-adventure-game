using UnityEngine;
using System.Collections;

public class SimpleChest : BaseContainer
{
	public Dialogue PickupDialogue;

	protected void OnRemoveItem()
	{
		if (this.PickupDialogue.Messages.Count > 0)
		{
			DialogueUIController.CurrentInstance.PlayDialogue(this.PickupDialogue);
		}

		Destroy(this.gameObject);
	}

	public override bool OnInteractItem(ItemUI holdingItem)
	{
		var currentItem = this.TargetItem;
		if (currentItem != null)
		{
			bool canAdd = InventoryUI.CurrentInstance.TryAddItem(currentItem);
			if (canAdd)
			{
				this.OnRemoveItem();
				this.TargetItem = null;
			}
		}

		return false;
	}

	public override void OnInteractElementalizer(Compound currentCompound)
	{
	}
}
