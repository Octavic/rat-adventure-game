using UnityEngine;
using System.Collections;

public abstract class BaseInteractable : MonoBehaviour
{
	public Color NormalColor;
	public Color HighlightColor;

	public float InteractionDistance;

	protected SpriteRenderer sprite;
	protected bool WasInRange { get; private set; }

	public virtual bool IsEnabled()
	{
		if (!this.IsInRange())
		{
			return false;
		}

		return true;
	}

	public bool IsInRange()
	{
		return (PlayerController.CurrentInstance.transform.position - this.transform.position).magnitude < this.InteractionDistance;
	}

	public abstract void OnInteract();

	protected virtual void OnEnterRange()
	{
		this.sprite.color = HighlightColor;
	}
	protected virtual void OnLeaveRange()
	{
		this.sprite.color = NormalColor;
	}

	// Use this for initialization
	protected virtual void Start()
	{
		this.sprite = this.GetComponent<SpriteRenderer>();
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
