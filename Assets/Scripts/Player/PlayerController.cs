using System.Collections;
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

	public void AutoMoveTo(Vector3 autoMoveGoal, float time = 1.0f)
	{
		this.autoMoveGoal = autoMoveGoal;
		this.autoMoveTimeLeft = time;
	}

	// Use this for initialization
	protected virtual void Start()
	{
		MainCamera.CurrentInstance.FocusObject = this.gameObject;
	}

	// Update is called once per frame
	protected virtual void Update()
	{
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
			if (Input.GetKey(KeyCode.A))
			{
				x--;
			}
			if (Input.GetKey(KeyCode.D))
			{
				x++;
			}

			int y = 0;
			if (Input.GetKey(KeyCode.W))
			{
				y++;
			}
			if (Input.GetKey(KeyCode.S))
			{
				y--;
			}

			this.transform.position += new Vector3(
				this.MovementSpeed * x * Time.deltaTime,
				this.MovementSpeed * y * Time.deltaTime
			);
		}
	}
}
