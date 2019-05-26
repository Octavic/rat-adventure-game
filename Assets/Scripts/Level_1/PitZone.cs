using UnityEngine;
using System.Collections;

public class PitZone : MonoBehaviour
{
	public CutSceneBars CutSceneBarsUI;
	public Animator PitAnimator;
	public MainCamera MainCameraComp;
	public Dialogue CantEnterDialogue;

	public SimpleChest ToothChest;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag != "Player")
		{
			return;
		}

		DialogueUIController.CurrentInstance.SetDialogue(this.CantEnterDialogue);
	}

	public IEnumerator PlayPitCatch()
	{
		this.CutSceneBarsUI.Show();
		yield return new WaitForSeconds(0.25f);

		var oldFocusObject = MainCameraComp.FocusObject;
		MainCameraComp.FocusObject = this.PitAnimator.gameObject;
		yield return new WaitForSeconds(0.25f);

		this.PitAnimator.SetBool("IsCatching", true);
		yield return new WaitForSeconds(2.5f);
		ToothChest.gameObject.SetActive(true);
		yield return new WaitForSeconds(0.5f);

		this.CutSceneBarsUI.Hide();
		yield return new WaitForSeconds(0.25f);
		MainCameraComp.FocusObject = oldFocusObject;

		Destroy(this.gameObject);
	}
}
