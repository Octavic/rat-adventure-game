using UnityEngine;
using System.Collections;

public class Plant : BaseInteractable
{
	public MeatContainer Meat;
	public Dialogue PlantHint;

	private bool isWithered = true;

	public override void OnInteractElementalizer(Compound currentCompound)
	{
		if (currentCompound == null)
		{
			return;
		}

		if (currentCompound.CompoundName == CompoundNames.Water)
		{
			this.GetComponent<Animator>().SetBool("IsGrowing", true);
			this.isWithered = false;
		}
	}

	public void OnCompleteGrowing()
	{
		this.Meat.Drop();
	}

	public override bool OnInteractItem(ItemUI holdingItem)
	{
		if(this.isWithered)
		{
			DialogueUIController.CurrentInstance.PlayDialogue(this.PlantHint);
		}

		return false;
	}
}
