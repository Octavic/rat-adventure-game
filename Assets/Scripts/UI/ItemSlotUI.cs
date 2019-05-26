using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemSlotUI : MonoBehaviour
{
	public ItemUI CurrentItem;

	public GameObject SelectionBoarder;

	public Text ItemName;

	public static ItemSlotUI CurrentlySelected { get; private set; }

	/// <summary>
	/// Called when the user simply clicks on the item slot
	/// </summary>
	public void OnClick()
	{
		if (CurrentlySelected == this)
		{
			CurrentlySelected = null;
			this.OnDeselect();
			return;
		}

		if (CurrentlySelected != null)
		{
			CurrentlySelected.OnDeselect();
		}

		this.SelectionBoarder.SetActive(true);
		CurrentlySelected = this;
	}
	private void OnDeselect()
	{
		this.SelectionBoarder.SetActive(false);
	}

	public void PlaceItem(ItemUI newItem)
	{
		this.CurrentItem = newItem;
		this.ResetItem();
		this.ItemName.text = newItem != null ? newItem.ItemName.ToString() : "";
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
		this.ItemName.text = "";

		return item;
	}

	// Use this for initialization
	void Start()
	{
		this.SelectionBoarder.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{

	}
}
