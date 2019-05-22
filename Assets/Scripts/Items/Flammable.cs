using UnityEngine;
using System.Collections;

public class Flammable : BaseInteractable
{
	public GameObject Flame;

	public bool IsOnFire { get; private set; }

	public override bool OnInteractItem(ItemUI holdingItem)
	{
		if (holdingItem != null && holdingItem.ItemName == ItemNames.Lighter && !this.IsOnFire)
		{
			this.OnSetFire();
		}

		return false;
	}

	public override void OnInteractElementalizer(Compound currentCompound)
	{
		if (currentCompound == null)
		{
			return;
		}

		if (currentCompound.CompoundName == CompoundNames.Water && this.IsOnFire)
		{
			this.OnExtinguishFire();
		}
	}

	protected void OnSetFire()
	{
		this.IsOnFire = true;
		this.Flame.SetActive(true);
	}

	protected void OnExtinguishFire()
	{
		this.IsOnFire = false;
		this.Flame.SetActive(false);
	}

	protected override void Start()
	{
		this.OnExtinguishFire();
		base.Start();
	}
}
