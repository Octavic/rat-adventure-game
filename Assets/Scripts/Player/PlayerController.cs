﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public static PlayerController CurrentInstance
	{
		get
		{
			if (_currentInstance == null)
			{
				_currentInstance = GameObject.FindObjectOfType<PlayerController>();
			}

			return _currentInstance;
		}
	}
	private static PlayerController _currentInstance;

	public float MovementSpeed;

	// For auto moving
	private Vector3 autoMoveGoal;
	private float autoMoveTimeLeft;

	// The rigidbody
	private Rigidbody2D rgbdComp;

	/// <summary>
	/// The animator component
	/// </summary>
	private Animator animatorComp;

	/// <summary>
	/// The animator param that the player was moving in
	/// </summary>
	private string wasFacing;

	public void AutoMoveTo(Vector3 autoMoveGoal, float time = 1.0f)
	{
		this.autoMoveGoal = autoMoveGoal;
		this.autoMoveTimeLeft = time;
	}

	// Use this for initialization
	protected virtual void Start()
	{
		MainCamera.CurrentInstance.FocusObject = this.gameObject;
		this.rgbdComp = this.GetComponent<Rigidbody2D>();
		this.animatorComp = this.GetComponent<Animator>();
	}

	// Update is called once per frame
	protected virtual void FixedUpdate()
	{
		// Do nothing if there's a dialogue going on
		if (DialogueUI.ActivePrompt != null)
		{
			return;
		}

		#region Handles movement
		if (this.autoMoveTimeLeft > 0)
		{
			this.transform.position = Vector3.Lerp(
				this.transform.position,
				this.autoMoveGoal,
				Time.deltaTime / this.autoMoveTimeLeft
			);
			this.autoMoveTimeLeft -= Time.deltaTime;
		}
		else
		{
			int x = 0;
			string newFacing = PlayerAnimationParams.FaceDown;
			if (Input.GetKey(KeyCode.A))
			{
				newFacing = PlayerAnimationParams.FaceLeft;
				x--;
			}
			if (Input.GetKey(KeyCode.D))
			{
				newFacing = PlayerAnimationParams.FaceRight;
				x++;
			}

			int y = 0;
			if (Input.GetKey(KeyCode.W))
			{
				newFacing = PlayerAnimationParams.FaceUp;
				y++;
			}
			if (Input.GetKey(KeyCode.S))
			{
				newFacing = PlayerAnimationParams.FaceDown;
				y--;
			}

			if (newFacing != this.wasFacing)
			{
				this.animatorComp.SetBool(this.wasFacing, false);
				this.animatorComp.SetBool(newFacing, true);
				this.wasFacing = newFacing;
			}

			this.animatorComp.SetBool(PlayerAnimationParams.IsMoving, x != 0 || y != 0);

			this.rgbdComp.MovePosition(
				this.transform.position + new Vector3(
					this.MovementSpeed * x * Time.deltaTime,
					this.MovementSpeed * y * Time.deltaTime
				)
			);
		}
		#endregion

		#region Handles interactions
		var isInteractItem = Input.GetKeyDown(KeyCode.Q);
		var isInteractElementalizer = Input.GetKeyDown(KeyCode.E);
		if (isInteractElementalizer || isInteractItem)
		{
			var curPos = this.transform.position;
			foreach (var interactable in GameObject.FindObjectsOfType<BaseInteractable>())
			{
				var distance = (interactable.transform.position - curPos).magnitude;
				if (distance < interactable.InteractionDistance)
				{
					if (isInteractItem)
					{
						interactable.OnInteractItem(ItemSlotUI.CurrentlySelected.CurrentItem);
					}
					else if (isInteractElementalizer)
					{
						interactable.OnInteractElementalizer(ElementalizerUI.CurrentInstance.CurrentCompound);
					}
				}
			}
		}
		#endregion
	}
}
