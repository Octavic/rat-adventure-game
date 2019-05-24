using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitZone1 : MonoBehaviour
{
	public CutSceneBars CutSceneBarsUI;
	public Animator PitAnimator;
	public MainCamera MainCameraComp;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag != "Player")
		{
			return;
		}

		StartCoroutine(this.PlayPitReveal());
	}

	public IEnumerator PlayPitReveal()
	{
		this.CutSceneBarsUI.Show();
		yield return new WaitForSeconds(0.25f);
		var oldFocusObject = MainCameraComp.FocusObject;
		MainCameraComp.FocusObject = this.PitAnimator.gameObject;
		yield return new WaitForSeconds(0.25f);
		this.PitAnimator.SetBool("IsRevealing", true);
		yield return new WaitForSeconds(7.0f);
		this.CutSceneBarsUI.Hide();
		yield return new WaitForSeconds(0.25f);
		MainCameraComp.FocusObject = oldFocusObject;
		Destroy(this.gameObject);
	}
}
