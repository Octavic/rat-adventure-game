using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapController : MonoBehaviour
{
	public static MapController CurrentInstance
	{
		get
		{
			if (_currentInstance == null)
			{
				_currentInstance = GameObject.FindObjectOfType<MapController>();
			}
			return _currentInstance;
		}
	}
	private static MapController _currentInstance;

	/// <summary>
	/// All interactable items
	/// </summary>
	[HideInInspector]
	public List<BaseInteractable> Interactables = new List<BaseInteractable>();

	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{

	}
}
