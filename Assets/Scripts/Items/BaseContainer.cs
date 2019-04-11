using UnityEngine;
using System.Collections;

public abstract class BaseContainer : MonoBehaviour, Interactable
{
	public Item ItemInSlot { get; private set; }

	public bool IsEmpty
	{
		get
		{
			return this.ItemInSlot != null;
		}
	}

	public bool IsEnabled()
	{
		return true;
	}

	public abstract void OnInteract();

	public virtual Item TryPlaceItem(Item item)
	{
		var oldItem = this.ItemInSlot;
		this.ItemInSlot = item;
		return oldItem;
	}
}
