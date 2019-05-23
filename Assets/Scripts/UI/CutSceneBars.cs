using UnityEngine;
using System.Collections;

public class CutSceneBars : MonoBehaviour
{
	private Animator AnimatorComp;
	public void Show()
	{
		this.AnimatorComp.SetBool("IsShowing", true);
	}
	public void Hide()
	{
		this.AnimatorComp.SetBool("IsShowing", false);
	}

	// Use this for initialization
	void Start()
	{
		this.AnimatorComp = this.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{

	}
}
