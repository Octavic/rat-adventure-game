using UnityEngine;
using System.Collections;

public abstract class BaseInteractable : MonoBehaviour
{
	public Color NormalColor;
	public Color HighlightColor;

	public float InteractionDistance;

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

	// Use this for initialization
	protected virtual void Start()
	{

	}

	// Update is called once per frame
	protected  virtual void Update()
	{
		this.GetComponent<SpriteRenderer>().color =
			(PlayerController.CurrentInstance.transform.position - this.transform.position).magnitude < this.InteractionDistance
			? HighlightColor
			: NormalColor;
	}
}
