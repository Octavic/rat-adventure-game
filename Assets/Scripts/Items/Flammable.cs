using UnityEngine;
using System.Collections;

public class Flammable : BaseInteractable
{
	public bool IsOnFire { get; private set; }

	public override bool OnInteractItem(ItemUI holdingItem)
	{
		// If not holding any items
		if (holdingItem == null)
		{
			return false;
		}

		if (holdingItem.ItemName == ItemNames.MatchStick && !this.IsOnFire)
		{
			this.OnSetFire();
		}

		return true;
	}

	public override void OnInteractElementalizer(Compound currentCompound)
	{
		if (currentCompound == null)
		{
			return;
		}

		if (currentCompound.Name == CompoundNames.Water && this.IsOnFire)
		{
			this.OnExtinguishFire();
		}
	}

	protected void OnSetFire()
	{
		this.IsOnFire = true;
	}

	protected void OnExtinguishFire()
	{
		this.IsOnFire = false;
	}
}
