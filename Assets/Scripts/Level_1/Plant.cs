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
}
