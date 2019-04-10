using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float MovementSpeed;
	
	// Use this for initialization
	protected virtual void Start()
	{
		MainCamera.CurrentInstance.FocusObject = this.gameObject;
	}

	// Update is called once per frame
	protected virtual void Update()
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

		if (x != 0)
		{
			this.transform.position += new Vector3(this.MovementSpeed * x * Time.deltaTime, 0);
		}
	}
}
