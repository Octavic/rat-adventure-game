using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
	/// <summary>
	/// A list of all slots, filling from first to last
	/// </summary>
	public List<ItemSlotUI> ItemSlots;

	public static InventoryUI CurrentInstance
	{
		get
		{
			if (_currentInstance == null)
			{
				_currentInstance = GameObject.FindObjectOfType<InventoryUI>();
			}
			return _currentInstance;
		}
	}
	private static InventoryUI _currentInstance;


	public bool TryAddItem(ItemUI newItem)
	{
		foreach(var slot in this.ItemSlots)
		{
			if(slot.CurrentItem == null)
			{
				slot.PlaceItem(newItem);
				return true;
			}
		}

		return false;
	}
}
