using UnityEngine;
using System.Collections;

public class MeatContainer : SimpleChest
{
	public void Drop()
	{
		this.GetComponent<Animator>().SetBool("IsFalling", true);
	}

	protected override void OnRemoveItem()
	{
		Destroy(this.gameObject);
		base.OnRemoveItem();
	}
}
