using UnityEngine;
using System.Collections;

public class RoomChangeDoor : BaseInteractable
{
	public Vector2 MoveToPosition;
	public float TransitionTime;

	public override void OnInteractElementalizer(Compound currentCompound)
	{
	}

	public override bool OnInteractItem(ItemUI holdingItem)
	{
		StartCoroutine(this.TransferCoroutine());
		return false;
	}

	private IEnumerator TransferCoroutine()
	{
		BlackScreen.FadeIn(TransitionTime);
		yield return new WaitForSeconds(TransitionTime);
		PlayerController.CurrentInstance.transform.position = this.MoveToPosition;
		BlackScreen.FadeOut(TransitionTime);
	}

	protected override void Start()
	{
		this.interactableUI.SetMessage("Open", true);
		this.interactableUI.SetMessage(null, false);

		base.Start();
	}
}
