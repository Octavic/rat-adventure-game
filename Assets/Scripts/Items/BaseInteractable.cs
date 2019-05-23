using UnityEngine;
using System.Collections;

public abstract class BaseInteractable : MonoBehaviour
{
	public bool CanInteractItem;
	public bool CanInteractElement;

	/// <summary>
	/// How far away the player  must be to trigger being in range
	/// </summary>
	public float InteractionDistance;

	protected bool WasInRange { get; private set; }

	public bool IsInRange()
	{
		return (PlayerController.CurrentInstance.transform.position - this.transform.position).magnitude < this.InteractionDistance;
	}

	public bool IsInteractable { get; protected set; }

	protected SpriteRenderer spriteComp;

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

	protected virtual void OnPlayerEnterRange()
	{
		InteractableUI.CurrentInstance.Claim(this);
		this.spriteComp.color = Config.InRangeColor;
	}
	protected virtual void OnPlayerLeaveRange()
	{
		InteractableUI.CurrentInstance.Unclaim();
		this.spriteComp.color = Config.OutOfRangeColor;
	}

	// Use this for initialization
	protected virtual void Start()
	{
		InteractableUI.CurrentInstance.SetState(this.CanInteractItem, this.CanInteractElement);
		this.spriteComp = this.GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	protected virtual void Update()
	{
		var isNowInRange = IsInRange();
		if (isNowInRange && !this.WasInRange)
		{
			this.OnPlayerEnterRange();
		}
		else if (!isNowInRange && this.WasInRange)
		{
			this.OnPlayerLeaveRange();
		}

		this.WasInRange = isNowInRange;
	}
}
