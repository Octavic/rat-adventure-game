﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour
{
	/// <summary>
	/// The item that's currently being held
	/// </summary>
	public ItemUI HoldingItem { get; private set; }

	/// <summary>
	/// The source slot for the currently holding item
	/// </summary>
	private ItemSlotUI SourceSlot;

	GraphicRaycaster graphicRayCaster;
	PointerEventData pointerEventData;
	EventSystem eventSystem;

	private ItemSlotUI GetMouseOverItemSlot()
	{
		//Set up the new Pointer Event
		pointerEventData = new PointerEventData(eventSystem);
		//Set the Pointer Event Position to that of the mouse position
		pointerEventData.position = Input.mousePosition;

		//Create a list of Raycast Results
		List<RaycastResult> results = new List<RaycastResult>();

		//Raycast using the Graphics Raycaster and mouse click position
		graphicRayCaster.Raycast(pointerEventData, results);

		foreach (var result in results)
		{
			var itemSlot = result.gameObject.GetComponent<ItemSlotUI>();
			if (itemSlot != null)
			{
				return itemSlot;
			}
		}

		return null;
	}

	private void ResetHolding()
	{
		this.HoldingItem = null;
		this.SourceSlot = null;
	}

	protected void Start()
	{
		//Fetch the Raycaster from the GameObject (the Canvas)
		graphicRayCaster = GetComponent<GraphicRaycaster>();
		//Fetch the Event System from the Scene
		eventSystem = GetComponent<EventSystem>();
	}

	// Update is called once per frame
	protected void Update()
	{
		var mousePosition = Input.mousePosition;
		if (this.HoldingItem != null)
		{
			this.HoldingItem.transform.position = mousePosition;
		}

		// On click
		if (Input.GetMouseButtonDown(0))
		{
			var itemSlot = this.GetMouseOverItemSlot();
			if (itemSlot != null && itemSlot.CurrentItem != null)
			{
				this.HoldingItem = itemSlot.CurrentItem;
				this.HoldingItem.transform.parent = this.transform;
				this.SourceSlot = itemSlot;
			}
		}

		// On release
		if (Input.GetMouseButtonUp(0))
		{
			if (this.HoldingItem == null)
			{
				// Release when holding nothing, so do nothing
				return;
			}

			var hoveringSlot = this.GetMouseOverItemSlot();
			if (hoveringSlot == null)
			{
				// Not releasing over item slot, reset
				this.SourceSlot.ResetItem();
				this.ResetHolding();
			}
			else
			{
				// Is releasing over item slot
				this.SourceSlot.RemoveItem();
				var replacedItem = hoveringSlot.RemoveItem();
				if(replacedItem != null)
				{
					this.SourceSlot.PlaceItem(replacedItem);
				}
				hoveringSlot.PlaceItem(this.HoldingItem);

				this.ResetHolding();
			}
		}
	}
}