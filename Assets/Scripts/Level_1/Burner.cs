using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burner : BaseInteractable
{
	public ItemUI MediumRareMeat;

	public GameObject MeatPrefab;
	public Vector2 MeatOffset;

	public Dialogue NeedFire;

	private Animator AnimatorComp;
	private AudioSource AudioComp;
	private bool isBurning;

	public override void OnInteractElementalizer(Compound currentCompound)
	{
		if (currentCompound == null)
		{
			return;
		}

		if (currentCompound.CompoundName == CompoundNames.Oxygen)
		{
			this.isBurning = true;
			this.AudioComp.mute = false;
			this.AnimatorComp.SetBool("IsBurning", true);
		}
		if (currentCompound.CompoundName == CompoundNames.Water)
		{
			this.isBurning = false;
			this.AudioComp.mute = true;
			this.AnimatorComp.SetBool("IsBurning", false);
		}
	}

	public override bool OnInteractItem(ItemUI holdingItem)
	{
		if (holdingItem == null || !this.isBurning)
		{
			DialogueUIController.CurrentInstance.PlayDialogue(this.NeedFire);
			return false;
		}

		if (holdingItem.ItemName == ItemNames.RawMeat)
		{
			this.StartCoroutine(this.CookCoroutine());
			return true;
		}

		return false;
	}

	private IEnumerator CookCoroutine()
	{
		var newMeat = Instantiate(this.MeatPrefab, this.transform);
		newMeat.transform.localPosition = this.MeatOffset;
		var yScale = 1;
		for (var i = 0; i < 5; i++)
		{
			yield return new WaitForSeconds(0.5f);
			newMeat.transform.localScale = new Vector3(1, yScale, 1);
			yScale *= -1;
		}

		Destroy(newMeat.gameObject);
		InventoryUI.CurrentInstance.TryAddItem(this.MediumRareMeat);
	}

	protected override void Start()
	{
		this.AnimatorComp = this.GetComponent<Animator>();
		this.AudioComp = this.GetComponent<AudioSource>();

		base.Start();
	}
}
