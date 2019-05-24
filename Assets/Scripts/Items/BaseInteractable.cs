using UnityEngine;
using System.Collections;

public abstract class BaseInteractable : MonoBehaviour
{
	public bool CanInteractItem;
	public bool CanInteractElement;

	public Vector2 UIOffset;

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

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			this.OnPlayerEnterRange();
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			this.OnPlayerLeaveRange();
		}
	}

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

	protected virtual void Update()
	{

	}
}
