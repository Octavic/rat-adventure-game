using UnityEngine;
using System.Collections;

public abstract class BaseContainer : BaseInteractable
{
	public ContainerUI UIObject;

	protected override void OnEnterRange()
	{
		this.UIObject.gameObject.SetActive(true);
		this.UIObject.transform.position = Camera.main.WorldToScreenPoint(this.transform.position);
		base.OnEnterRange();
	}
	protected override void OnLeaveRange()
	{
		this.UIObject.gameObject.SetActive(false);
		base.OnLeaveRange();
	}

	protected override void Update()
	{
		if (this.UIObject.gameObject.activeInHierarchy)
		{
			var oldPosition = this.UIObject.transform.position;
			var newPosition = Camera.main.WorldToScreenPoint(this.transform.position);
			this.UIObject.transform.position = Vector3.Lerp(oldPosition, newPosition, 0.2f);
		}

		base.Update();
	}
}
