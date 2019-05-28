using UnityEngine;
using System.Collections;

public class MeatContainer : SimpleChest
{
	public void Drop()
	{
		this.GetComponent<Animator>().SetBool("IsFalling", true);
	}

	public void PlayMeatSlap()
	{
		this.GetComponent<AudioSource>().Play();
	}
}
