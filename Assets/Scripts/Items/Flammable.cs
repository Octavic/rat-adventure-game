using UnityEngine;
using System.Collections;

public class Flammable : BaseInteractable
{
	public bool IsOnFire { get; private set; }

	public override void OnInteractItem(ItemUI holdingItem)
	{
		if (holdingItem == null)
		{
			return;
		}

		if (holdingItem.ItemName == ItemNames.MatchStick && !this.IsOnFire)
		{
			this.OnSetFire();
		}
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
