using UnityEngine;
using System.Collections;

public class PitZone : MonoBehaviour
{
	public CutSceneBars CutSceneBarsUI;
	public Animator PitAnimator;
	public MainCamera MainCameraComp;
	public Dialogue CantEnterDialogue;

	private bool HasReveled = false;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag != "Player")
		{
			return;
		}

		if(!this.HasReveled)
		{
			StartCoroutine(this.PlayPitReveal());
			this.HasReveled = true;
		}
		else
		{

		}
	}

	private IEnumerator PlayPitReveal()
	{
		this.CutSceneBarsUI.Show();
		yield return new WaitForSeconds(0.25f);
		var oldFocusObject = MainCameraComp.FocusObject;
		MainCameraComp.FocusObject = this.PitAnimator.gameObject;
		yield return new WaitForSeconds(0.25f);
		this.PitAnimator.SetBool("IsRevealing", true);
		yield return new WaitForSeconds(3.0f);
		this.CutSceneBarsUI.Hide();
		yield return new WaitForSeconds(0.25f);
		MainCameraComp.FocusObject = oldFocusObject;

	}

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
