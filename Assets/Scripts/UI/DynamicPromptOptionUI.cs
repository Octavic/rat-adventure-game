using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DynamicPromptOptionUI : MonoBehaviour
{
	public DynamicPromptUI.DynamicDialogueOption TargetOption;

	public static DynamicPromptOptionUI CurrentSelected;

	private Text TextBox;

	public void SetOption(DynamicPromptUI.DynamicDialogueOption option)
	{
		this.TargetOption = option;
	}

	public void OnSelect()
	{
		if (CurrentSelected != null)
		{
			CurrentSelected.OnDeselect();
		}

		this.TextBox.text = "> " + this.TargetOption.OptionMessage;
	}
	public void OnDeselect()
	{
		this.TextBox.text = "  " + this.TargetOption.OptionMessage;
	}
}
