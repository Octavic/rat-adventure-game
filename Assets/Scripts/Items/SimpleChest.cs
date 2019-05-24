using UnityEngine;
using System.Collections;

public class SimpleChest : BaseContainer
{
	protected void OnRemoveItem()
	{
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
