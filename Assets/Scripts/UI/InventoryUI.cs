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
}
