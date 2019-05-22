using UnityEngine;
using System.Collections;

public class RoomChangeDoor : BaseInteractable
{
	public Vector3 MoveToPosition;
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
		MainCamera.CurrentInstance.transform.position = this.MoveToPosition.WithZ(MainCamera.CurrentInstance.CameraDepth);
		BlackScreen.FadeOut(TransitionTime);
	}
}
