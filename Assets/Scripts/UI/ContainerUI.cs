using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ContainerUI : MonoBehaviour
{
	/// <summary>
	/// All of the slots on the container
	/// </summary>
	public List<ItemSlotUI> Slots;

	/// <summary>
	/// Gets all of the items 
	/// </summary>
	/// <returns></returns>
	public List<ItemUI> AllItems()
	{
		return this.Slots.Select(slot => slot.CurrentItem).ToList();
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
