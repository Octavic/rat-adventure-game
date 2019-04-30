using UnityEngine;
using System.Collections;

public class InventoryUI : MonoBehaviour
{
	public static InventoryUI CurrentInstance
	{
		get
		{
			if (_currentInstance == null)
			{
				_currentInstance = GameObject.FindObjectOfType<InventoryUI>();
			}
			return _currentInstance;
		}
	}
	private static InventoryUI _currentInstance;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
