using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InteractableUI : MonoBehaviour
{
	public GameObject ItemPromptUI;
	public GameObject ElementalizerUI;

	public BaseInteractable Target { get; set; }

	public void SetState(bool canInteractItem, bool canInteractElement)
	{
		this.ItemPromptUI.SetActive(canInteractItem);
		this.ElementalizerUI.SetActive(canInteractElement);
	}

	public void AlignWithTarget()
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
