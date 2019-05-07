using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InteractableUI : MonoBehaviour
{
	public Text TextBox;

	public InteractPromptUI ItemPromptUI;
	public InteractPromptUI ElementalizerUI;

	public BaseInteractable Target { get; set; }

	public void SetMessage(string message, bool isItem)
	{
		var targetPrompt = isItem ? ItemPromptUI : ElementalizerUI;
		if (message == null)
		{
			targetPrompt.HidePrompt();
		}
		else
		{
			targetPrompt.Message = message;
			targetPrompt.ShowPrompt();
		}
	}

	private void AlignWithTarget()
	{
		this.transform.position = MainCamera.CameraComp.WorldToScreenPoint(this.Target.transform.position);
	}

	// Update is called once per frame
	void Update()
	{
		if(this.Target != null)
		{
			this.AlignWithTarget();
		}
	}

	private void Start()
	{
		this.gameObject.SetActive(false);
	}
}
