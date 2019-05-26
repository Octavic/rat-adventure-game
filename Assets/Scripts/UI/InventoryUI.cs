using UnityEngine;
using System.Linq;
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

	public bool Has(ItemNames item)
	{
		return this.ItemSlots.Any(itemSlot => itemSlot.CurrentItem != null && itemSlot.CurrentItem.ItemName == item);
	}

	public bool TryAddItem(ItemUI newItem)
	{
		foreach (var slot in this.ItemSlots)
		{
			if (slot.CurrentItem == null)
			{
				slot.PlaceItem(newItem);
				newItem.gameObject.SetActive(true);
				return true;
			}
		}

		return false;
	}

	public void RemoveItem(ItemNames item)
	{
		foreach (var slot in this.ItemSlots)
		{
			if (slot.CurrentItem != null && slot.CurrentItem.ItemName == item)
			{
				var removed = slot.RemoveItem();
				Destroy(removed.gameObject);
			}
		}
	}

	protected void Update()
	{
		var startingIndex = (int)KeyCode.Alpha1;
		for (var i = 0; i < this.ItemSlots.Count; i++)
		{
			if (Input.GetKeyDown((KeyCode)startingIndex + i))
			{
				this.ItemSlots[i].OnClick();
			}
		}
	}
}
