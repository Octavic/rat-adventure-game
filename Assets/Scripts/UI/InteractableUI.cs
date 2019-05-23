﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InteractableUI : MonoBehaviour
{
	public static InteractableUI CurrentInstance
	{
		get
		{
			if (currentInstance == null)
			{
				currentInstance = GameObject.FindObjectOfType<InteractableUI>();
			}
			return currentInstance;

		}
	}
	private static InteractableUI currentInstance;

	public GameObject ItemPromptUI;
	public GameObject ElementalizerUI;

	public BaseInteractable Target;

	public void SetState(bool canInteractItem, bool canInteractElement)
	{
		this.ItemPromptUI.SetActive(canInteractItem);
		this.ElementalizerUI.SetActive(canInteractElement);
	}

	public void AlignWithTarget()
	{
		this.transform.position = MainCamera.CameraComp.WorldToScreenPoint(this.Target.transform.position);
	}

	public void Claim(BaseInteractable owner)
	{
		this.Target = owner;
		this.AlignWithTarget();
		this.SetState(owner.CanInteractItem, owner.CanInteractElement);
		this.gameObject.SetActive(true);
	}

	public void Unclaim()
	{
		this.Target = null;
		this.gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		if (this.Target != null)
		{
			this.AlignWithTarget();
		}
	}

	private void Start()
	{
		this.gameObject.SetActive(false);
	}
}
