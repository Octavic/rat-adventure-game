using UnityEngine;
using System.Collections;

public class Plant : BaseInteractable
{
	public MeatContainer Meat;

	public override void OnInteractElementalizer(Compound currentCompound)
	{
		if (currentCompound == null)
		{
			return;
		}

		if (currentCompound.CompoundName == CompoundNames.Water)
		{
			this.GetComponent<Animator>().SetBool("IsGrowing", true);
		}
	}

	public void OnCompleteGrowing()
	{
		this.Meat.Drop();
	}

	public override bool OnInteractItem(ItemUI holdingItem)
	{
		return false;
	}

	protected override void OnPlayerEnterRange()
	{
		base.OnPlayerEnterRange();
	}

	protected override void Start()
	{
		this.interactableUI.SetMessage(null, true);
		base.Start();
	}

	protected override void Update()
	{
		var currentCompound = ElementalizerUI.CurrentInstance.CurrentCompound;
		var isUsingWater = currentCompound != null && currentCompound.CompoundName == CompoundNames.Water;
		this.interactableUI.SetMessage(isUsingWater ? "Water" : null, false);

		base.Update();
	}
}
