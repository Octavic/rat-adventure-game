using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public AudioSource FootStepSource;

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
	private string wasFacing = PlayerAnimationParams.FaceDown;

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
		if (FindObjectOfType<DialogueUI>() != null)
		{
			this.animatorComp.SetBool(PlayerAnimationParams.IsMoving, false);
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

			var isMoving = x != 0 || y != 0;
			this.animatorComp.SetBool(PlayerAnimationParams.IsMoving, isMoving);
			this.FootStepSource.mute = !isMoving;

			this.rgbdComp.MovePosition(
				this.transform.position + new Vector3(
					this.MovementSpeed * x * Time.deltaTime,
					this.MovementSpeed * y * Time.deltaTime
				)
			);
		}
		#endregion

		#region Handles interactions
		var isInteractItem = Input.GetKeyDown(KeyCode.E);
		var isInteractElementalizer = Input.GetKeyDown(KeyCode.Q);
		if (isInteractElementalizer || isInteractItem)
		{
			// Find the interactable items
			var interactable = InteractableUI.CurrentInstance.Target;
			if (interactable != null)
			{
				// Can only interact with one way at a time
				if (isInteractItem)
				{
					var currentSelected = ItemSlotUI.CurrentlySelected;
					bool shouldUseUp = interactable.OnInteractItem(currentSelected == null ? null : currentSelected.CurrentItem);

					if (shouldUseUp)
					{
						var removedItem = currentSelected.RemoveItem();
						if (removedItem != null)
						{
							Destroy(removedItem.gameObject);
						}
					}
				}
				else if (isInteractElementalizer)
				{
					interactable.OnInteractElementalizer(ElementalizerUI.CurrentInstance.CurrentCompound);
				}
			}
		}
		#endregion
	}
}
