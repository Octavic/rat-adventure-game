using UnityEngine;
using System.Collections;

public class ItemSlotUI : MonoBehaviour
{
	public ItemUI CurrentItem;

	public void PlaceItem(ItemUI newItem)
	{
		this.CurrentItem = newItem;
		this.ResetItem();
	}

	public void ResetItem()
	{
		if (this.CurrentItem != null)
		{
			this.CurrentItem.transform.SetParent(this.transform);
			this.CurrentItem.transform.localPosition = new Vector3();
		}
	}

	public ItemUI RemoveItem()
	{
		var item = this.CurrentItem;
		this.CurrentItem = null;
		return item;
	}

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
