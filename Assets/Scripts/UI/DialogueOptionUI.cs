using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class DialogueOptionUI : MonoBehaviour
{
	/// <summary>
	/// Arrow that marks this option as being selected
	/// </summary>
	public GameObject SelectedArrow;

	/// <summary>
	/// The option that this UI represents
	/// </summary>
	public DialogueOption TargetOption;

	/// <summary>
	/// The option that's currently selected
	/// </summary>
	public static DialogueOptionUI CurrentSelected;

	/// <summary>
	/// Sets the tracking option
	/// </summary>
	/// <param name="option">The option to be represented</param>
	public void SetOption(DialogueOption option)
	{
		this.GetComponent<Text>().text = option.OptionMessage;
		this.TargetOption = option;
	}

	public void OnSelect()
	{
		if (CurrentSelected != null)
		{
			CurrentSelected.OnDeselect();
		}

		this.SelectedArrow.gameObject.SetActive(true);
		CurrentSelected = this;
	}

	public void OnDeselect()
	{
		this.SelectedArrow.gameObject.SetActive(false);
	}
}
