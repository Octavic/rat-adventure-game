using UnityEngine;
using System.Collections;

public abstract class BaseContainer : MonoBehaviour
{
	public Item ItemInSlot { get; private set; }

	public bool IsEmpty
	{
		get
		{
			return this.ItemInSlot != null;
		}
	}

	public virtual Item TryPlaceItem(Item item)
	{
		var oldItem = this.ItemInSlot;
		this.ItemInSlot = item;
		return oldItem;
	}
}
