using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InteractPromptUI : MonoBehaviour
{
	public Text TextComp;

	public string Message { get
		{
			return _message;
		}
		set
		{
			this.TextComp.text = value;
			this._message = value;
		}
	}

	private string _message;

	/// <summary>
	/// Used for initialization
	/// </summary>
	private void Start()
	{
		this.TextComp = this.GetComponentInChildren<Text>();
	}

	public void ShowPrompt()
	{
		if(!string.IsNullOrEmpty( this._message))
		{
			this.gameObject.SetActive(true);
		}
	}

	public void HidePrompt()
	{
		this.gameObject.SetActive(false);
	}
}
