using UnityEngine;
using System.Collections;

public class SimpleChest : BaseContainer
{
	protected override void Start()
	{
		var currentItem = this.TargetItem;
		this.interactableUI.SetMessage(currentItem != null ? "Take " + currentItem.ItemName : null, true);
		this.interactableUI.SetMessage(null,  false);

		base.Start();
	}

	protected virtual void OnRemoveItem()
	{

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
				this.interactableUI.SetMessage(null, true);
				this.TargetItem = null;
			}
		}

		return false;
	}

	public override void OnInteractElementalizer(Compound currentCompound)
	{
	}
}
