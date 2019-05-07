using UnityEngine;
using System.Collections;

public abstract class BaseInteractable : MonoBehaviour
{
	/// <summary>
	/// UI related
	/// </summary>
	public InteractableUI interactableUI;

	public float InteractionDistance;

	protected bool WasInRange { get; private set; }

	public bool IsInRange()
	{
		return (PlayerController.CurrentInstance.transform.position - this.transform.position).magnitude < this.InteractionDistance;
	}

	public bool IsInteractable { get; protected set; }

	/// <summary>
	/// Interacts with this with the holding item
	/// </summary>
	/// <param name="holdingItem">The item  that the player is currently holding</param>
	/// <returns>If the item is used up</returns>
	public abstract bool OnInteractItem(ItemUI holdingItem);

	/// <summary>
	/// Interacts with this with the elementalizer
	/// </summary>
	/// <param name="currentCompound">The current compound in use</param>
	public abstract void OnInteractElementalizer(Compound currentCompound);

	protected virtual void OnEnterRange()
	{
		this.interactableUI.Target = this;
		this.interactableUI.gameObject.SetActive(true);
	}
	protected virtual void OnLeaveRange()
	{
		this.interactableUI.gameObject.SetActive(false);
	}

	// Use this for initialization
	protected virtual void Start()
	{
	}

	// Update is called once per frame
	protected virtual void Update()
	{
		var isNowInRange = IsInRange();
		if (isNowInRange && !this.WasInRange)
		{
			this.OnEnterRange();
		}
		else if (!isNowInRange && this.WasInRange)
		{
			this.OnLeaveRange();
		}

		this.WasInRange = isNowInRange;
	}
}
