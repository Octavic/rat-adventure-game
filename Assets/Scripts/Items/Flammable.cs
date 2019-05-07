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

		if (currentCompound.Name == CompoundNames.Water && this.IsOnFire)
		{
			this.OnExtinguishFire();
		}
	}

	protected void OnSetFire()
	{
		this.IsOnFire = true;
		this.Flame.SetActive(true);
		this.interactableUI.SetMessage(null, true);
	}

	protected void OnExtinguishFire()
	{
		this.IsOnFire = false;
		this.Flame.SetActive(false);
		this.interactableUI.SetMessage(null, false);
	}

	private void UpdateText()
	{
		var currentSelected = ItemSlotUI.CurrentlySelected;
		var isSelectingLighter = currentSelected != null && currentSelected.CurrentItem.ItemName == ItemNames.Lighter;
		this.interactableUI.SetMessage(isSelectingLighter && !this.IsOnFire ? "Light on fire" : null, true);

		var currentCompound = ElementalizerUI.CurrentInstance.CurrentCompound;
		var isUsingWater = currentCompound != null && currentCompound.Name == CompoundNames.Water;
		this.interactableUI.SetMessage(isUsingWater && this.IsOnFire ? "Extinguish" : null, false);

	}

	protected override void Start()
	{
		this.OnExtinguishFire();
		base.Start();
	}

	protected override void Update()
	{
		this.UpdateText();
		base.Update();
	}
}
